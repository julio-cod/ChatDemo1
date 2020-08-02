using ChatDemo1.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChatDemo1.Data
{
    public class DataContext : IDisposable
    {
        private SQLiteConnection cnn;

        public DataContext()
        {

            cnn = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "DBchatdemo.db3"));
            cnn.CreateTable<UsuarioLocalModel>();


        }

        public void Dispose()
        {
            cnn.Dispose();
        }

        public void Insertar(UsuarioLocalModel modelo)
        {
            cnn.Insert(modelo);
        }
        public void Actualizar(UsuarioLocalModel modelo)
        {
            cnn.Update(modelo);
        }
        public void Eliminar(UsuarioLocalModel modelo)
        {
            cnn.Delete(modelo);
        }
        public UsuarioLocalModel Consultar(int id)
        {
            return cnn.Table<UsuarioLocalModel>().FirstOrDefault(p => p.IdUsuario == id);
        }

        public List<UsuarioLocalModel> Consultar()
        {
            return cnn.Table<UsuarioLocalModel>().ToList();
        }

        public UsuarioLocalModel ConsultaUsuarioLocal(int id)
        {
           
            return cnn.Table<UsuarioLocalModel>().FirstOrDefault(p => p.IdUsuario == id);


            //return cnn.Query<UsuarioLocalModel>("select * from Valuation where IdUsuario = ?", id);


        }

    }
}
