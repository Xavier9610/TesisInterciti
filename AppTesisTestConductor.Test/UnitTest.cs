using System.Text;

namespace AppTesisTestConductor.Test
{
    public class UnitTest
    {
        [Fact]
        public void TestCorreoValido()
        {
            Assert.True(Validaciones.EsCorreoValido("ga-xavier@live.com"));
        }
        [Fact]
        public void TestCorreoNoValido()
        {
            Assert.False(Validaciones.EsCorreoValido("gasrgtrgcom"));
        }
        [Fact]
        public void TestCedulaValido()
        {
            Assert.True(Validaciones.VerificaIdentificacion("1724718182"));
        }
        [Fact]
        public void TestCedulaNoValido()
        {
            Assert.False(Validaciones.VerificaIdentificacion("1234567890"));
        }
        [Fact]
        public void TestTelefonoValido()
        {
            Assert.True(Validaciones.ValidarTelefonos10Digitos("0960400373"));
        }
        [Fact]
        public void TestTelefonoNoValido()
        {
            Assert.False(Validaciones.ValidarTelefonos10Digitos("2766627"));
        }
        //Servicio
        [Fact]
        public void CompresionDeBytes()
        {
            string test = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            bool assert = false;
            byte[] bytes = Encoding.ASCII.GetBytes(test);
            var compressByte = Servicio.Compress(bytes);
            if (compressByte.Length < bytes.Length)
            {
                assert = true;
            }
            Assert.True(assert);
        }
        [Fact]
        public void LoginCI()
        {
            var distancia = Servicio.GetLoginCI("1724718182", "12345678");
            Assert.NotNull(distancia);
        }
        [Fact]
        public void LoginCIError()
        {
            var distancia = Servicio.GetLoginCI("1724718182", "123456789");
            Assert.Null(distancia);
        }
        [Fact]
        public void LoginCorreo()
        {
            var distancia = Servicio.GetLoginCorreo("ga-xavier@live.com", "12345678");
            Assert.NotNull(distancia);
        }
        [Fact]
        public void LoginCorreoError()
        {
            var distancia = Servicio.GetLoginCorreo("ga-xavier@live.com", "123456789");
            Assert.Null(distancia);
        }
    }
}