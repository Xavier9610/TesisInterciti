using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BaseDeDatos;
namespace BaseDeDatos.Test
{
    [TestClass]
    public class UnitTest
    {
        Metodos client = new Metodos();
		private static int valorEsperado;
		[TestMethod]
		public void AgregarClienteTest()
		{
			valorEsperado = client.AgregarCliente("ClienteServicio","", "Garcia", "1123081031", "erika.leon@epn.edu.ec", "0993081031", DateTime.Now, "TestUser", null);
			Assert.AreEqual(0, valorEsperado);
		}
		//                     Vehiculos                       /
		[TestMethod]
		public void AAgregarVehiculoTest()
		{
			client.AgregarVehiculo("GRN0739", 1, 1, 1, 1, null);
			client.AgregarVehiculo("GRN0739", 2, 2, 2, 2, null);
			valorEsperado = client.AgregarVehiculo("GRN0739", 3, 3, 3, 3, null);
			Assert.AreEqual(0, valorEsperado);
		}
		[TestMethod]
		public void AgregarRecorridoTest()
		{
			client.AgregarRecorrido((Decimal)0.00, (Decimal)0.00, (Decimal)0.00, (Decimal)0.000, DateTime.Now, (Decimal)1.00, 4, 4, 1, 1, "");
			valorEsperado = client.AgregarRecorrido((Decimal)0.00, (Decimal)0.00, (Decimal)0.00, (Decimal)0.000, DateTime.Now, (Decimal)1.00, 5, 5, 1, 1, "");
			Assert.AreEqual(0, valorEsperado);
		}
		//                     CONDUCTORES                         /
		[TestMethod]
		public void AgregarConductoresTest()
		{
			client.AgregarConductores("Conductor1", "abc123", 5, "Garcia", "1724718182", "patricio.garcia@epn.edu.ec", "0960400373", DateTime.Now, false, "TestUser", null);
			client.AgregarConductores("Conductor2", "abc123", 4, "Garcia", "1724718182", "patricio.garcia@epn.edu.ec", "0960400373", DateTime.Now, false, "TestUser", null);
			valorEsperado = client.AgregarConductores("Conductor2", "abc123", 5, "Garcia", "1724718182", "patricio.garcia@epn.edu.ec", "0960400373", DateTime.Now, false, "TestUser", null);
			Assert.AreEqual(0, valorEsperado);
		}
		//                     ADMIN                         /
		[TestMethod]
		public void AgregarAdminTest()
		{
			client.AgregarAdmin("Admin1", "abc123", "Garcia", "1724718182", "patricio.garcia@epn.edu.ec", "0960400373", DateTime.Now, false, "TestUser", null);
			valorEsperado = client.AgregarAdmin("Admin2", "abc123", "Garcia", "1724718182", "patricio.garcia@epn.edu.ec", "0960400373", DateTime.Now, false, "TestUser", null);
			Assert.AreEqual(0, valorEsperado);
		}

		//
		[TestMethod]
		public void TestListarClientes()
		{
			Assert.IsNotNull(client.ListarClientes());
		}
		[TestMethod]
		public void TestEliminarCliente()
		{
			valorEsperado = client.EliminarCliente(2);
			Assert.AreEqual(0, valorEsperado);
		}
		[TestMethod]
		public void TestActualizarCliente()
		{
			Cliente cliente = new Cliente();
			cliente.Nombre = "Gabriel";
			cliente.Apellido = "Garcia";
			cliente.Correo = "gabriela.garcia@itsa.edu.ec";
			cliente.Cedula = "1234567890";
			cliente.FechaNacimiento = DateTime.Today;
			cliente.IdCliente = 4;
			cliente.Telefono = "0227666627";
			cliente.Pass = "123abc";
			client.ActualizarCliente(cliente);
			Assert.AreEqual(0, valorEsperado);

		}

		//listar conductor
		[TestMethod]
		public void TestListarConductores()
		{
			Assert.IsNotNull(client.ListarConductores());
		}
		//Eliminar conductor
		[TestMethod]
		public void TestEliminarConductor()
		{
			valorEsperado = client.EliminarConductor(2);
			Assert.AreEqual(0, valorEsperado);
		}
		//Editar conductor
		[TestMethod]
		public void TestActualizarConductor()
		{
			Conductor conductor = new Conductor();
			conductor.Nombre = "Gabriel";
			conductor.Apellido = "Garcia";
			conductor.Correo = "gabriela.garcia@itsa.edu.ec";
			conductor.Cedula = "1234567890";
			conductor.FechaNacimiento = DateTime.Today;
			conductor.IdConductor = 4;
			conductor.Telefono = "0227666627";
			conductor.Pass = "123abc";
			conductor.IdVehiculo = 1;
			client.ActualizarConductor(conductor);
			Assert.AreEqual(0, valorEsperado);
		}

		//listar conductor
		[TestMethod]
		public void TestListarAdmin()
		{
			Assert.IsNotNull(client.ListarAdmin());
		}
		//Eliminar conductor
		[TestMethod]
		public void TestEliminarAdmin()
		{
			valorEsperado = client.EliminarAdmin(2);
			Assert.AreEqual(0, valorEsperado);
		}
		//Editar conductor
		[TestMethod]
		public void TestActualizarAdmin()
		{
			Admin admin = new Admin();
			admin.Nombre = "Gabriel";
			admin.Apellido = "Garcia";
			admin.Correo = "gabriela.garcia@itsa.edu.ec";
			admin.Cedula = "1234567890";
			admin.FechaNacimiento = DateTime.Today;
			admin.IdAdmin = 4;
			admin.Telefono = "0227666627";
			admin.Pass = "123abc";
			client.ActualizarAdmin(admin);
			Assert.AreEqual(0, valorEsperado);
		}

		//listar conductor
		[TestMethod]
		public void TestListarVehiculo()
		{
			Assert.IsNotNull(client.ListarVehiculo());
		}
		//Eliminar conductor
		[TestMethod]
		public void TestEliminarVehiculo()
		{
			valorEsperado = client.EliminarVehiculo(2);
			Assert.AreEqual(0, valorEsperado);
		}
		//Editar conductor
		[TestMethod]
		public void TestActualizarVehiculo()
		{
			Vehiculo vehiculo = new Vehiculo();
			vehiculo.IdAño = 1;
			vehiculo.IdVehiculo = 4;
			vehiculo.IdModelo =2;
			vehiculo.IdTipo = 4;
			vehiculo.Placa = "PBX0985";
			client.ActualizarVehiculo(vehiculo);
			Assert.AreEqual(0, valorEsperado);
		}
		//                      Recorrido                       /
		//listar conductor
		[TestMethod]
		public void TestListarRecorrido()
		{
			Assert.IsNotNull(client.ListarRecorrido());
		}


		//Eliminar conductor
		[TestMethod]
		public void TestEliminarRecorrido()
		{
			valorEsperado = client.EliminarRecorrido(2);
			Assert.AreEqual(0, valorEsperado);
		}

		[TestMethod]
		//Editar conductor
		public void TestActualizarRecorrido()
		{
			Recorrido recorrido = new Recorrido();
			recorrido.FechaRecorrido = DateTime.Today;
			recorrido.IdCliente = 2;
			recorrido.IdConductor = 2;
			recorrido.IdRecorrido = 2;
			recorrido.LatitudDestino = (Decimal)1.0;
			recorrido.LatitudOrigen = (Decimal)1.0;
			recorrido.LongitudDestino = (Decimal)1.0;
			recorrido.LongitudOrigen = (Decimal)1.0;
			recorrido.ValorRecorrido = (Decimal)1.0;
			client.ActualizarRecorrido(recorrido);
			Assert.AreEqual(0, valorEsperado);
		}
	}
}
