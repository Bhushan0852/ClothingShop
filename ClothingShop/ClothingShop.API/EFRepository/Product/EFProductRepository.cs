using ClothingShop.API.Data;
using ClothingShop.API.Models.Domains;
using ClothingShop.API.Models.DTOs;
using ClothingShop.API.Repository.IEFRepository.Product;
using Microsoft.Extensions.FileProviders;

namespace ClothingShop.API.Repository.Repository.Product
{
    public class EFProductRepository : IEFProductRepository
    {
        private readonly ClothingShopDbContext dbContext;
        private readonly IWebHostEnvironment webHost;

        public EFProductRepository(ClothingShopDbContext dbContext, IWebHostEnvironment webHost)
        {
            this.dbContext = dbContext;
            this.webHost = webHost;
        }

        public async Task<bool> CreateProduct(CreateProductDTO createProductDTO, List<IFormFile> fileData)
        {
            var prodId = 0;
            var pBrand = dbContext.ProductBrands.FirstOrDefault(x => x.Id == createProductDTO.ProductBrandId);
            var prod = dbContext.Products.Where(z => !z.IsDeleted && z.ProductBrandId == createProductDTO.ProductBrandId).ToList();
            List<int> incValue = new();
            foreach (var item in prod)
            {
                string data = item.IncValue.Substring(item.IncValue.Length - 4);
                incValue.Add(int.Parse(data));
            }
            int incMax = incValue.Max() + 1;

            Models.Domains.Product product = new Models.Domains.Product();

            product.SKUCode = pBrand.BrandCode.Substring(0, 1) + "" + incMax.ToString();
            product.ProductTitle = createProductDTO.ProductTitle;
            product.ProductDitails = createProductDTO.ProductDitails;
            product.ProductPrice = createProductDTO.ProductPrice;
            product.ProductQty = createProductDTO.ProductQty;
            product.ProductBrandId = createProductDTO.ProductBrandId;
            product.ProductSizeId = createProductDTO.ProductSizeId;
            product.ProductColourId = createProductDTO.ProductColourId;
            product.IncValue = incMax.ToString();
            product.VendorCode = "P-XYZ-0001";
            product.CreatedBy = "test";
            product.UpdatedBy = "";
            product.CreatedByTimeStamp = DateTime.Now.ToString();
            product.UpdatedByTimeStamp = "";
            await dbContext.Products.AddAsync(product);
            prodId = await dbContext.SaveChangesAsync();

            var Products = dbContext.Products.FirstOrDefault(x => x.SKUCode == product.SKUCode);
            if (fileData != null)
            {
                if (fileData != null && fileData.Any())
                {

                    try
                    {
                        fileData.ForEach(async file =>
                        {

                            var fileDetails = new FileDetails()
                            {
                                ID = Guid.NewGuid(),
                                FileName = file.FileName,
                                ProductId = Products.Id

                            };
                            using (var stream = new MemoryStream())
                            {
                                file.CopyTo(stream);
                                fileDetails.FileData = stream.ToArray();
                            }
                            var result = dbContext.FileDetails.Add(fileDetails);

                            var content = new System.IO.MemoryStream(fileDetails.FileData);
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "Product//" + Products.SKUCode + "//", fileDetails.FileName);
                            await CopyStream(content, path);


                        });
                        await dbContext.SaveChangesAsync();

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            if(prodId > 0)
            {
                return true;
            }
            return false;
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            FileInfo fileInfo = new FileInfo(downloadPath);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);

            }
        }
        public async Task<IEnumerable<Models.Domains.Product>> GetAllAsync()
        {
            var data = dbContext.Products.Where(C => !C.IsDeleted).ToList();
            List<Models.Domains.Product> products = new List<Models.Domains.Product>();
            foreach (var item in data)
            {
                Models.Domains.Product product = new Models.Domains.Product();
                product = item;
                product.ProductBrand = dbContext.ProductBrands.FirstOrDefault(x => x.Id == item.ProductBrandId);
                product.ProductColour = dbContext.ProductColours.FirstOrDefault(x => x.Id == item.ProductColourId);
                product.ProductSize = dbContext.ProductSizes.FirstOrDefault(x => x.Id == item.ProductSizeId);
                product.FileDetails = dbContext.FileDetails.Where(C => !C.IsDeleted && C.ProductId == item.Id).ToList();
                products.Add(product);
            }

            return products;
        }

        public async Task<Models.Domains.Product> SearchSkuProducts(string skuName)
        {
            var data = dbContext.Products.FirstOrDefault(e => e.SKUCode == skuName);

            if (data != null)
            {
                data = new();
            }

            return data;
        }

        public async Task<Models.Domains.Product> GetProductPreview(Guid guid)
        {
            var data = dbContext.Products.Where(c => c.Id == guid && !c.IsDeleted).FirstOrDefault();

            Models.Domains.Product product = new Models.Domains.Product();
            product = data;
            product.ProductBrand = dbContext.ProductBrands.FirstOrDefault(x => x.Id == data.ProductBrandId);
            product.ProductColour = dbContext.ProductColours.FirstOrDefault(x => x.Id == data.ProductColourId);
            product.ProductSize = dbContext.ProductSizes.FirstOrDefault(x => x.Id == data.ProductSizeId);
            product.FileDetails = dbContext.FileDetails.Where(C => !C.IsDeleted && C.ProductId == data.Id).ToList();
            return product;
        }

        public async Task<Models.Domains.Product> GetProductDetail(Guid guid)
        {
            var data = dbContext.Products.Where(c => c.Id == guid && !c.IsDeleted).FirstOrDefault();

            Models.Domains.Product product = new Models.Domains.Product();
            product = data;
            product.ProductBrand = dbContext.ProductBrands.FirstOrDefault(x => x.Id == data.ProductBrandId);
            product.ProductColour = dbContext.ProductColours.FirstOrDefault(x => x.Id == data.ProductColourId);
            product.ProductSize = dbContext.ProductSizes.FirstOrDefault(x => x.Id == data.ProductSizeId);
            product.FileDetails = dbContext.FileDetails.Where(C => !C.IsDeleted && C.ProductId == data.Id).ToList();
            return product;
        }

        public async Task<bool> RemoveProduct(Guid guid)
        {
            Models.Domains.Product data;
            data = dbContext.Products.Where(c => c.Id == guid && !c.IsDeleted).FirstOrDefault();
            if (data != null)
            {
                data.IsDeleted = true;
                data.UpdatedBy = "test";
                data.UpdatedByTimeStamp = DateTime.Now.ToString();
                dbContext.Update(data);
                await dbContext.SaveChangesAsync();
            }
            //var data1 = data != null ? data : new Models.Domains.Product(); 
            return true;
        }
        public async Task<Models.Domains.Product> UpdateProduct(Models.DTOs.UpdateProductDTO updateProductDTO)
        {
            var data = dbContext.Products.Where(x => x.Id == updateProductDTO.Id && !x.IsDeleted).FirstOrDefault();
            if (data != null)
            {
                // Models.Domains.Product product = new Models.Domains.Product();
                data.ProductTitle = updateProductDTO.ProductTitle;
                data.ProductDitails = updateProductDTO.ProductDitails;
                data.ProductPrice = updateProductDTO.ProductPrice;
                data.ProductQty = updateProductDTO.ProductQty;
                //product.Discount= updateProductDTO.Discount;
                dbContext.Update(data);
                await dbContext.SaveChangesAsync();
            }
            return data;
        }

        public async Task<Models.Domains.Product> CreateCloneProduct(CreateProductDTO createProductDTO)
        {
            var pBrand = dbContext.ProductBrands.FirstOrDefault(x => x.Id == createProductDTO.ProductBrandId);
            Models.Domains.Product product = new Models.Domains.Product();

            product.SKUCode = pBrand.BrandCode.Substring(0, 1) + "" + "001";
            product.ProductTitle = createProductDTO.ProductTitle;
            product.ProductDitails = createProductDTO.ProductDitails;
            product.ProductPrice = createProductDTO.ProductPrice;
            product.ProductQty = createProductDTO.ProductQty;
            product.ProductBrandId = createProductDTO.ProductBrandId;
            product.ProductSizeId = createProductDTO.ProductSizeId;
            product.ProductColourId = createProductDTO.ProductColourId;
            product.CreatedBy = "test";
            product.UpdatedBy = "";
            product.CreatedByTimeStamp = DateTime.Now.ToString();
            product.UpdatedByTimeStamp = "";
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> UserAddedProduct(Guid userId, Guid productId,int Qty)
        {
            bool result = false;
            int count = 0;
            for (int i = 0; i < Qty; count++)
            {
                Models.Domains.UserProducts userProducts = new Models.Domains.UserProducts();
                userProducts.UserId = userId;
                userProducts.ProductId = productId;
                userProducts.IsDeleted = false;
                userProducts.CreatedBy = "test";
                userProducts.CreatedByTimeStamp = DateTime.Now.ToString();
                await dbContext.UserProducts.AddAsync(userProducts);
                count = await dbContext.SaveChangesAsync();

                i++;
                //if (count > 0)
                //{
                //    count++;
                //}
            }
            if(count > 0)
            {
                result = true;  
            }
            return result;
        }

        public async Task<bool> RemoveUserAddedProduct(Guid userId, Guid productId)
        {
            bool result = false;
            int count = 0;

            var cartItems = dbContext.UserProducts.Where(x => !x.IsDeleted && x.ProductId == productId && x.UserId == userId).ToList();
            foreach (var item in cartItems)
            {
                Models.Domains.UserProducts userProducts = new Models.Domains.UserProducts();
                item.IsDeleted = true;
                item.UpdatedBy = "test";
                item.UpdatedByTimeStamp = DateTime.Now.ToString();
                dbContext.UserProducts.Update(item);
                count = await dbContext.SaveChangesAsync();
                if (count > 0)
                {
                    count = count + 1;
                }
            }
            if (count > 0)
            {
                result = true;
            }
            return result;
        }


        public async Task<bool> PlaceOrder(Guid userId, Guid productId)
        {
            bool result = false;
            int count = 0;

            var cartItems = dbContext.UserProducts.Where(x => !x.IsDeleted && x.ProductId == productId && x.UserId == userId).ToList();
            foreach (var item in cartItems)
            {
                Models.Domains.UserProducts userProducts = new Models.Domains.UserProducts();
                item.OrderStatus = true;
                item.OutForDelivery = true;
                item.UpdatedBy = "test";
                item.UpdatedByTimeStamp = DateTime.Now.ToString();
                dbContext.UserProducts.Update(item);
                count = await dbContext.SaveChangesAsync();
                if (count > 0)
                {
                    count = count + 1;
                }
            }
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
