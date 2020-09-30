using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto.Models;

namespace Tests.Models
{

    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void Cpf_vazio_invalid()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "0");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void Cpf_quantidade_caracteres_diferente_onze_invalid()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "0000");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void TestarNomeQuantidadeCaracteresMenorTres()
        {
            var cliente = new Cliente("Vi", DateTime.Now, "0000000000");
            Assert.IsTrue(cliente.Invalid);
        }


        [TestMethod]
        public void TestarEntidadeValida()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "96332824204");
            Assert.IsTrue(cliente.Valid);
        }
    }
}