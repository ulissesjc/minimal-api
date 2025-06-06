using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Domínio.Entidades;
using minimal_api.Infraestrutura.Db;
using minimal_api.Infraestrutura.Serviços;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseSqlServer(configuration.GetConnectionString("ConexaoPadrao"));

        return new DbContexto(options.Options);
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Cadastrar(adm);

        // Assert
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
    }

    public void TestandoBuscarPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Cadastrar(adm);
        var admDoBanco = administradorServico.BuscarPorId(adm.Id);

        // Assert
        Assert.AreEqual(1, admDoBanco.Id);

    }
}