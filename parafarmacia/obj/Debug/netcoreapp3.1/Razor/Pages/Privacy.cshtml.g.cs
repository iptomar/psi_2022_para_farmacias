#pragma checksum "/Users/gabrielbonet/Documents/PSI/psi_2022_para_farmacias/parafarmacia/Pages/Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fd0b2cf82ee1ab940a25059f1e989ba29b4685b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(parafarmacia.Pages.Pages_Privacy), @"mvc.1.0.razor-page", @"/Pages/Privacy.cshtml")]
namespace parafarmacia.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/Users/gabrielbonet/Documents/PSI/psi_2022_para_farmacias/parafarmacia/Pages/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gabrielbonet/Documents/PSI/psi_2022_para_farmacias/parafarmacia/Pages/_ViewImports.cshtml"
using parafarmacia;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gabrielbonet/Documents/PSI/psi_2022_para_farmacias/parafarmacia/Pages/_ViewImports.cshtml"
using parafarmacia.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fd0b2cf82ee1ab940a25059f1e989ba29b4685b", @"/Pages/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b9746a9e28681d02854d18a43f116533de57649", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Privacy : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/gabrielbonet/Documents/PSI/psi_2022_para_farmacias/parafarmacia/Pages/Privacy.cshtml"
  
    ViewData["Title"] = "Política de Privacidade";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>
</h1>
<div>
    <p>Aplicação Web desenvolvida por:</p>
    <p>Gabriel Bonet nº21373 </p>
    <p>Hernâni Diniz nº18891 </p>
    <p>João Correia nº21302 </p>
    <p>João Batista nº21079 </p>
    <p>André D'Sá nº00000 </p>



    <p>
        A Parafarmácia trata-se de uma aplicação web que serve para gerir um conjunto de produtos de beleza e medicamentos sem prescrição.
        Também serve como loja para compra dos mesmos produtos.<br />
        Temos presentes dois cargos, Admin e User. <br />
        Com o cargo de Admin, é possível gerir o site de modo a adicionar produtos e categoria, assim como alterar
        o role de users para Admin.<br />
        O User pode apenas ver os produtos atuais adicioná-los ao carrinho e por sua vez ""comprar"", simulando uma encomenda.


    </p>
    <br />
    <p>Frameworks:</p>
    <ul>
        <li>
            ASP NET CORE 3.1
        </li>
        <li>
            Entity Framework
        </li>
    </ul>

    <br />
    <p>Dados de acesso na seed:</p>
    <ul>
      ");
            WriteLiteral(@"  <li>
            Admin
            <ul>
                <li>Email: admin@admin</li>
                <li>Password: admin</li>
            </ul>
        </li>
    </ul>
    <br />
    <br />
    <p>GitHub:</p>
    <ul>
        <li>
            <a href=""https://github.com/iptomar/psi_2022_para_farmacias.git"">
                https://github.com/iptomar/psi_2022_para_farmacias.git
            </a>
        </li>
    </ul>
</div>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PrivacyModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PrivacyModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PrivacyModel>)PageContext?.ViewData;
        public PrivacyModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
