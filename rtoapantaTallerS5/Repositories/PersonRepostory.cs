using rtoapantaTallerS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace rtoapantaTallerS5.Repositories
{
    public class PersonRepostory
    {
        private string _dbPath;
        private SQLiteConnection _conn;

        public string Message { get; set; }

        public void Init()
        {
            if (_conn is not null)
                return;
            _conn = new (_dbPath);
            _conn.CreateTable<Persona>(); 
        }

        public PersonRepostory(string path)
        {
            _dbPath = path;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona persona = new Persona();
                persona.Name = name;
                result = _conn.Insert(persona);
                Message = string.Format("Dato ingresado ", result, name);
            }
            catch (Exception ex) {
                Message = string.Format("Error " + ex.Message);
            }
            finally { DesconectarBase(); }
        }

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex) {
                Message = string.Format("Error " + ex.Message);
            }
            finally { DesconectarBase(); }
            return new List<Persona>();
        }

        public void UpdatePerson(int id, string name)
        {
            try
            {
                Init();

                if (id <= 0)
                    throw new Exception("El Id es requerido");

                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("El nombre es requerido");

                Persona persona = new Persona
                {
                    Id = id,
                    Name = name
                };

                int result = _conn.Update(persona);

                Message = result > 0
                    ? $"Persona actualizada correctamente: {name}"
                    : "No se encontró la persona para actualizar";
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }
            finally
            {
                DesconectarBase();
            }
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();

                if (id <= 0)
                    throw new Exception("El Id es requerido");

                int result = _conn.Delete<Persona>(id);

                Message = result > 0
                    ? "Persona eliminada correctamente"
                    : "No se encontró la persona para eliminar";
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }
            finally
            {
                DesconectarBase();
            }
        }

        private void DesconectarBase()
        {
            if (_conn is null)
                return;

            _conn.Dispose();
            _conn = null;
        }

        public void Dispose()
        {
            _conn?.Dispose();
            _conn = null;
            GC.SuppressFinalize(this);
        }
    }
}
