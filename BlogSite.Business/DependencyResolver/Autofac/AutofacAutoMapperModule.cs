﻿using Autofac;
using AutoMapper;

namespace BlogSite.Business.DependencyResolver.Autofac
{
    public class AutofacAutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(a => CreateConfiguration()).As<IMapper>();
        }
        private IMapper CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(GetType().Assembly);
            });
            return config.CreateMapper();
        }
    }
}