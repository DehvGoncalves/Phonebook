// Define o namespace onde a classe Program está localizada
namespace MeuSiteEmMVC {
    // Define a classe Program
    public class Program {
        // Método Main, ponto de entrada da aplicação
        public static void Main(string[] args) {
            // Cria um WebApplicationBuilder usando os argumentos da linha de comando
            // é usado para configurar e inicializar uma aplicação web ASP.NET Core.
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao contêiner de injeção de dependência para suportar controllers e views
            // é usado para registrar os serviços necessários para suportar o padrão de design Model-View-Controller (MVC) na aplicação ASP.NET Core.
            // Essa linha de código é essencial para habilitar o suporte a controllers e views na aplicação we
            builder.Services.AddControllersWithViews();

            // Constrói a aplicação
            var app = builder.Build();

            // Configura o pipeline de requisição HTTP
            if (!app.Environment.IsDevelopment()) {
                // Se não estiver em ambiente de desenvolvimento, configura o tratamento de exceções
                app.UseExceptionHandler("/Home/Error");
                // Define o tempo de HSTS (HTTP Strict Transport Security) para aumentar a segurança
                // Link de referência fornecido para mais informações sobre HSTS
                // (https://aka.ms/aspnetcore-hsts)
                app.UseHsts();
            }


            //CONFIGURAÇÕES PADRÕES DO PIPELINE DE REQUISIÇÃO HTTP

            // Redireciona todas as requisições HTTP para HTTPS
            app.UseHttpsRedirection();

            // Habilita o uso de arquivos estáticos (CSS, JavaScript, imagens, etc.)
            app.UseStaticFiles();

            // Habilita o roteamento de requisições
            app.UseRouting();

            // Habilita a autorização para controle de acesso
            app.UseAuthorization();


            //POR PADRÃO O PROJETO STARTA NA CONTROLLER HOMER E NA ACTION INDEX, COM UM PADRÃO QUE PODE SER NULL OU VIR PREENCHIDO 
            // Mapeia uma rota padrão para os controladores
            //O método app.MapControllerRoute() é usado p configurar uma rota padrão para os controladores. Especifica que por padrão,
            //quando a aplicação recebe a requisição sem um controlador ou ação especifica na URL, ele redirecionará para a Ation Index do controlador Home
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            /*{controller=Home}: Define o controlador padrão como Home.
             *{action=Index}: Define a action padrão como Index.
             *{id?}: Indica que o parâmetro id é opcional na rota.*/

            /* uma "Action" é um método dentro de um controlador que executa uma determinada funcionalidade em resposta a uma requisição HTTP
             * As actions são responsáveis por processar as requisições do cliente e retornar uma resposta adequada, que pode ser uma página HTML, um JSON
             * No exemplo fornecido, a action Index seria responsável por mostrar a página inicial do site.
             * No exemplo fornecido, a action Index seria responsável por mostrar a página inicial do site.*/

            // Inicia a execução da aplicação
            app.Run();
        }
    }

}
