using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using RCVUcabBackend.BussinesLogic.DTOs;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.Persistence;

namespace RCVUcabBackend.Tests.DataSeed

{
    public static class DataSeedProveedor
    { 
        public static Mock<DbSet<ProveedorEntity>> mockSetProveedor = new Mock<DbSet<ProveedorEntity>>();
    public static Mock<DbSet<MarcaEntity>> mockSetMarca = new Mock<DbSet<MarcaEntity>>();


    public static ProveedorDTO requests = new ProveedorDTO
    {
        nombre = "Proveedor 5",
        direccion = "Av Romulo Gallegos, Edif Aloa, Piso 5, Local 30",
        telefono = "04125897799",
        marcas = new List<MarcaDTO>
        {
            new MarcaDTO()
            {
                nombre = "Hyundai"
            }

        }
    };

    public static ProveedorDTO requests1 = new ProveedorDTO
    {
        nombre = "Proveedor 4",
        direccion = "Av Romulo Gallegos, Edif Aloa, Piso 5, Local 30",
        telefono = "04125897799",
        marcas = new List<MarcaDTO>
        {
            new MarcaDTO()
            {
                nombre = "Hyundai 3"
            }

        }
    };

    public static ProveedorDTO requests3 = new ProveedorDTO
    {
        nombre = "Proveedor Juan",
        direccion = "Caracas, Catia, Calle colombia 234",
        telefono = "04245896696",
        marcas = new List<MarcaDTO>
        {
            new MarcaDTO()
            {
                nombre = "Toyota 3"
            }

        }
    };

    public static List<ProveedorEntity> requests2 = new List<ProveedorEntity>
    {
        new ProveedorEntity()
        {
            Id = new Guid("9f1605fb-5a6a-4779-b289-1f9abfc942b0"),
            CreatedAt = DateTime.Now,
            CreatedBy = null,
            UpdatedAt = null,
            UpdatedBy = null,
            nombre = "Proveedor Mocaco",
            direccion = "Valencia",
            telefono = "02125889742",
            marcas = new List<MarcaEntity>
            {
                new MarcaEntity
                {
                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    CreatedAt = DateTime.Now,
                    CreatedBy = null,
                    UpdatedAt = null,
                    UpdatedBy = null,
                    nombre = "Ford"
                }

            }
        }

    };

    public static void SetupDbContextData(this Mock<IRCVDbContext> _mockCOntext, string tipo)
    {
        var requestsMarcas = requests2.SelectMany(p => p.marcas).Concat(new List<MarcaEntity>
        {
        });
        _mockCOntext.Setup(c => c.Marcas).Returns(mockSetMarca.Object);
        _mockCOntext.Setup(c => c.Proveedores).Returns(mockSetProveedor.Object);
        _mockCOntext.Setup(c => c.Marcas).Returns(requestsMarcas.AsQueryable().BuildMockDbSet().Object);
        _mockCOntext.Setup(c => c.Proveedores).Returns(requests2.AsQueryable().BuildMockDbSet().Object);
        _mockCOntext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
    }


}

}