﻿using DemoEcommerce.API.Data;
using DEmoECommerce.Library.Models;
using DEmoECommerce.Library.Responses;
using Microsoft.EntityFrameworkCore;

namespace DemoEcommerce.API.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext appDbContext;

        public ProductService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddProductAsync(Product product)
        {
            if (product == null) return new ServiceResponse() { Message = "Bad Request", Success = false };
            var chk= await appDbContext.Products.Where(p=>p.Name.ToLower().Equals(product.Name.ToLower())).FirstOrDefaultAsync();
            if (chk == null)
            {
                appDbContext.Products.Add(product);
                await appDbContext.SaveChangesAsync();
                return new ServiceResponse() { Message = "Product added", Success = true };
            }
            return new ServiceResponse() { Message = "Product already added", Success = false };
        }

        public async Task<ServiceResponse> DeleteProductAsync(int Id)
        {
            var product= await appDbContext.Products.FirstOrDefaultAsync(p=>p.Id == Id);
            if(product is null) return new ServiceResponse() { Message = "Product not found", Success = false };
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(){ Message = "Product deleted", Success = true };
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product=await appDbContext.Products.FirstOrDefaultAsync(p=>p.Id== id);
            return product;
        }

        public Task<List<Product>> GetProductsAsync()=> appDbContext.Products.ToListAsync();

        public async Task<ServiceResponse> UpdateProductAsync(Product product)
        {
            var result = await appDbContext.Products.Include(c=>c.Category).FirstOrDefaultAsync(p => p.Id == product.Id);
            if(result is null) return new ServiceResponse() { Message = "Product no found", Success = false };
            result.Name=product.Name;
            result.Description=product.Description;
            result.Price=product.Price;
            result.Quantity=product.Quantity;
            result.Image=product.Image;
            result.CategoryId=product.CategoryId;

           // appDbContext.Update(product);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(){ Message = "Product update", Success = true };
        }
    }
}
