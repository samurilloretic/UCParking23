using System;
using UCP.App.Dominio;
using UCP.App.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace UCP.App.Consola
{
    class Program
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Esto es un mensaje por consola");
            //AddProfesor();
            Profesor profesor = BuscarProfesorConVehiculo(13);
            Console.WriteLine(profesor.nombre);
            Console.WriteLine(profesor.apellidos);
            Console.WriteLine(profesor.facultad);
            Console.WriteLine(profesor.vehiculo_1.id);//no funciona
            Console.WriteLine(profesor.vehiculo_1.marca);//no funciona
            Console.WriteLine(profesor.vehiculo_1.modelo);//no funciona
            Console.WriteLine(profesor.vehiculo_1.placa);//no funciona
            Console.WriteLine(profesor.vehiculo_1.tipoVehiculo);//no funciona
            Console.WriteLine(profesor.vehiculo_2.marca);//no funciona
            //BuscarProfesor(1);
            //BuscarProfesores();
            //EliminarProfesor(3);
            //ActualizarProfesor();
            Vehiculo vehiculo_p = new Vehiculo{marca="Toyota", modelo="Corola",placa="COR123",tipoVehiculo=TipoVehiculo.Automovil};
            Vehiculo vehiculo_s = new Vehiculo{marca="Kia", modelo="Sportage",placa="SPO542",tipoVehiculo=TipoVehiculo.Camioneta};

            AdicionaProfesorConVehiculo(vehiculo_p,vehiculo_s);
            //BuscarProfesores();                        

            //BuscarProfesores();

            Console.WriteLine("Fin del programa");
        }


        //AddProfesor

        private static void AddProfesor()
        {
            var profesor = new Profesor 
            {
               nombre = "Jairo",
               apellidos = "Maya",
               identificacion = 123100001,
               correo =  "jairomaya.tic@ucaldas.edu.co",
               telefono ="30231000001",
               vehiculo_1 = null,
               vehiculo_2 = null,
               facultad ="Ciencias Computacionales",
               departamento = "Ingeniería",
               cubiculo ="Tres" 
            };

            Console.WriteLine(profesor.nombre+"\n Cubiculo= "+profesor.cubiculo);
            Profesor profesor_retornado = _repoProfesor.AddProfesor(profesor);
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        }
        //GetProfesor
        private static Profesor BuscarProfesor(int idProfesor)
        {
            var profesor = _repoProfesor.GetProfesor(idProfesor);
            //Console.WriteLine(profesor.nombre+" "+profesor.apellidos+"\n Facultad: "+profesor.facultad + " "+profesor.departamento+"\n Identificación: "+profesor.identificacion+"\n Telefono: "+profesor.telefono);
            return profesor;
        }
        //DeleteProfesor

        private static void EliminarProfesor(int idProfesor)
        {
            _repoProfesor.DeleteProfesor(idProfesor);
        }
        //UpdateProfesor
        private static void ActualizarProfesor()
        {
            var profesor = new Profesor 
            {
               id = 9,
               nombre = "Angelica",
               apellidos = "Muñoz",
               identificacion = 100000010,
               correo =  "angelicamuñoz.tic@ucaldas.edu.co",
               telefono ="30000000020",
               vehiculo_1 = null,
               vehiculo_2 = null,
               facultad ="Ingeniería",
               departamento = "Ciencias Computacionales",
               cubiculo ="Tres"
            };
            Profesor profesor_retornado =_repoProfesor.UpdateProfesor(profesor);                         
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        
        }
        //GetAllProfesores
        private static void BuscarProfesores()
        {
            IEnumerable<Profesor> profesores = _repoProfesor.GetAllProfesores();
            
            foreach (var profesor in profesores)
            {
                Console.WriteLine(profesor.nombre);
            }
            //Console.WriteLine(profesores.First().nombre);
        }

        private static void AdicionaProfesorConVehiculo()
        {
            var profesor = new Profesor 
            {
               nombre = "Catalina",
               apellidos = "Gómez",
               identificacion = 102543614,
               correo =  "catalinagomez.tic@ucaldas.edu.co",
               telefono ="3013013020",
               vehiculo_1 = new Vehiculo{marca="Renault", modelo="Clio",placa="ABA121",tipoVehiculo=TipoVehiculo.Coupe},
               vehiculo_2 = new Vehiculo{marca="Kawasaki", modelo="Ninja",placa="RAM12A",tipoVehiculo=TipoVehiculo.Motocicleta},
               facultad ="Ciencias Computacionales",
               departamento = "Ingeniería",
               cubiculo ="Tres" 
            };

            Console.WriteLine(profesor.nombre+"\n Cubiculo= "+profesor.cubiculo);
            Profesor profesor_retornado = _repoProfesor.AddProfesor(profesor);
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        }


        private static void AdicionaProfesorConVehiculo(Vehiculo pVehiculo,Vehiculo sVehiculo)
        {
            var profesor = new Profesor 
            {
               nombre = "Simón",
               apellidos = "Gaviria",
               identificacion = 105348213,
               correo =  "simongaviria.tic@ucaldas.edu.co",
               telefono ="3251323413",
               vehiculo_1 = pVehiculo,
               vehiculo_2 = sVehiculo,
               facultad ="Odontología",
               departamento = "Salud",
               cubiculo ="ocho" 
            };

            Console.WriteLine(profesor.nombre+"\n Cubiculo= "+profesor.cubiculo);
            Profesor profesor_retornado = _repoProfesor.AddProfesor(profesor);
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        }

        private static Profesor BuscarProfesorConVehiculo(int idProfesor)
        {
            var profesor = _repoProfesor.GetProfesorConVehiculo(idProfesor);        
            return profesor; 
        }
    }
}
