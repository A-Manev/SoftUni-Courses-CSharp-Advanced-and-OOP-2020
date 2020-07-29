﻿namespace FastFood.Core.Controllers
{
    using System.Linq;

    using AutoMapper;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Positions;

    public class PositionsController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public PositionsController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var position = this.mapper.Map<Position>(model);

            this.context.Positions.Add(position);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Positions");
        }

        public IActionResult All()
        {
            var positions = this.context
                .Positions
                .ProjectTo<PositionsAllViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(positions);
        }
    }
}
