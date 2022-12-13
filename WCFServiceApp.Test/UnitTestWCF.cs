using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
namespace WCFServiceApp.Test
{
    [TestClass]
    public class UnitTestWCF
    {

		public static System.ServiceModel.BasicHttpsBinding result = new System.ServiceModel.BasicHttpsBinding
		{
			MaxBufferPoolSize = int.MaxValue,
			ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max,
			MaxReceivedMessageSize = int.MaxValue,
			AllowCookies = true,
			OpenTimeout = new System.TimeSpan(10, 10, 0),
			ReceiveTimeout = new System.TimeSpan(10, 10, 0),
			SendTimeout = new System.TimeSpan(10, 10, 0)
		};
		public static ServiceReferenceInterciti. ServiceClient client = new ServiceReferenceInterciti.ServiceClient(result, new System.ServiceModel.EndpointAddress("https://wcfserviceappinterciti.azurewebsites.net/Service.svc"));

		private static int valorEsperado;
		[TestMethod]
		public void AgregarClienteTest()
		{
			valorEsperado = client.AgregarCliente("ClienteServicio",client.sha256_hash( client.GenerarPass()), "Garcia", "1123081031", "erika.leon@epn.edu.ec", "0993081031", DateTime.Now, "TestUser", null);
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
			ServiceReferenceInterciti.Cliente cliente = new ServiceReferenceInterciti.Cliente();
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
			ServiceReferenceInterciti.Conductor conductor = new ServiceReferenceInterciti.Conductor();
			conductor.Nombre = "Gabriel";
			conductor.Apellido = "Garcia";
			conductor.Correo = "gabriela.garcia@itsa.edu.ec";
			conductor.Cedula = "1234567890";
			conductor.FechaNacimiento = DateTime.Today;
			conductor.IdConductor = 4;
			conductor.Telefono = "0227666627";
			conductor.Pass = "123abc";
			conductor.Vehiculo = client.FindVehiculoByID(5);
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
			ServiceReferenceInterciti.Admin admin = new ServiceReferenceInterciti.Admin();
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
			ServiceReferenceInterciti.Vehiculo vehiculo = new ServiceReferenceInterciti.Vehiculo();
			vehiculo.Año1 = "2021";
			vehiculo.IdVehiculo = 4;
			vehiculo.Modelo1 = "SONATA";
			vehiculo.Tipo1 = "SEDAN";
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
			ServiceReferenceInterciti.Recorrido recorrido = new ServiceReferenceInterciti.Recorrido();
			recorrido.FechaRecorrido = DateTime.Today;
			recorrido.IdCliente = new ServiceReferenceInterciti.Cliente { IdCliente = 1 };
			recorrido.IdConductor = new ServiceReferenceInterciti.Conductor { IdConductor = 1 }; ;
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
