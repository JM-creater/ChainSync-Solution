using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;
using ChainSyncSolution.Application.Features.InventoryFeatures.Commands.CreateInventory;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.CreateProducts;

namespace ChainSyncSolution.Application.Interfaces.ErrorControl;

public interface IExceptionConfiguration
{
    Task CustomerRegisterValidator(RegisterCommand command);
    Task CustomSupplierRegister(SupplierRegisterCommand command);
    Task CustomLoginValidator(LoginQueries queries);
    Task CustomCreateProduct(CreateProductsCommand command);
    Task CustomCreateInventoryValidator(CreateInventoryCommand command);
}
