// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace InventoryServer.Components.Products
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using InventoryServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using InventoryServer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\_Imports.razor"
using InventoryServer.Components.Products;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\Components\Products\ListProductComponent.razor"
using Business;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\Components\Products\ListProductComponent.razor"
using Entities;

#line default
#line hidden
#nullable disable
    public partial class ListProductComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "C:\Me\.net-examples\blazor\.net\MiFirstAppInBlazor\InventoryServer\Components\Products\ListProductComponent.razor"
       
    IList<ProductEntity> products = new List<ProductEntity>();
    IList<ProductEntity> tempProducts = new List<ProductEntity>();
    IList<CategoryEntity> categories = new List<CategoryEntity>();

    protected override async Task OnInitializedAsync()
    {
        products = _product.ListProduct();
        tempProducts = products;
        categories = _category.CategoryList();
    }

    private void CategoryChange(ChangeEventArgs e)
    {
        tempProducts = products.Where(c=> c.CategoryId == e.Value.ToString()).ToList();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IB_Category _category { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IB_Product _product { get; set; }
    }
}
#pragma warning restore 1591
