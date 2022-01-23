﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebStore.Services.Interfaces;

namespace WebStore.Components;

public class SectionsViewComponent : ViewComponent
{
    private readonly IProductData _ProductData;

    public SectionsViewComponent(IProductData ProductData)
    {
        _ProductData = ProductData;
    }
    public IViewComponentResult Invoke()
    {
        var sections = _ProductData.GetSections();


        return View(_ProductData);
    }
}