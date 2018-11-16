using AutoMapper;
using NetCoreFramework.Application.Core.DTO.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Application.Core.DTO.TestPurpose
{
    public class ProfileRegistration
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new Map()));

            
        }
    }
}
