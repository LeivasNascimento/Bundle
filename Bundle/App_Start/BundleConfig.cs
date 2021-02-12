using System.Web;
using System.Web.Optimization;

namespace Bundle
{
    public class BundleConfig //reduz o número de requisições ao servidor, para que mais usuários possam usar o sistema com melhor desempenho
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true; //todas as ref abaixo vão ser 'compactadas' e usáveis na aplicação

            bundles.Add(new ScriptBundle("~/comum").IncludeDirectory("~/Scripts/comum", "*.js", true));
            //~/comum é o diretório virtual que vc referencia na view; true é para poder pegar todas as subpastas do diretório 
            // especificado em ~/Scripts/comum

            //exemplo para ignorar alguns scripts
            bundles.IgnoreList.Ignore("*.bdg.js");

            var ordem = new BundleFileSetOrdering("meuScript");
            ordem.Files.Add("setup.js");
            ordem.Files.Add("display.js");
            bundles.FileSetOrderList.Insert(0, ordem);


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include( //~/bundles/jquery é o diretório virtual que vc referencia na view
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
