﻿using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;
using ChainSyncSolution.Application.Features.InventoryFeatures.Commands.CreateInventory;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.CreateProducts;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.Persistence;

namespace ChainSyncSolution.Infrastructure.Common.ErrorControl;

public class ExceptionConfiguration : IExceptionConfiguration
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRespository _producerRespository;

    public ExceptionConfiguration(IUserRepository userRepository, IProductRespository producerRespository)
    {
        _userRepository = userRepository;
        _producerRespository = producerRespository;
    }

    public async Task CustomerRegisterValidator(RegisterCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.FirstName))
        {
            throw new FirstNameEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.LastName))
        {
            throw new LastNameEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Email))
        {
            throw new EmailEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.PhoneNumber))
        {
            throw new PhoneNumberEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Gender))
        {
            throw new GenderEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Password))
        {
            throw new PasswordEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Address))
        {
            throw new AddressEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.CompanyName))
        {
            throw new CompanyNameEmptyException();
        }

        if (await _userRepository.GetUserByPhoneNumberAsync(command.PhoneNumber) != null)
        {
            throw new PhoneNumberExistsException(command.PhoneNumber);
        }

        if (await _userRepository.GetUserByEmailAsync(command.Email) != null)
        {
            throw new EmailExistsException(command.Email);
        }
    }

    public async Task CustomSupplierRegister(SupplierRegisterCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.SupplierId))
        {
            throw new SupplierIdEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Address))
        {
            throw new AddressEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Email))
        {
            throw new EmailEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.PhoneNumber))
        {
            throw new PhoneNumberEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Password))
        {
            throw new PasswordEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Address))
        {
            throw new AddressEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.BizLicenseNumber))
        {
            throw new BizLicenseNumberEmptyException();
        }

        if (await _userRepository.GetUserByPhoneNumberAsync(command.BizLicenseNumber) != null)
        {
            throw new BizLicenseNumberExistsException(command.BizLicenseNumber);
        }

        if (await _userRepository.GetUserByPhoneNumberAsync(command.PhoneNumber) != null)
        {
            throw new PhoneNumberExistsException(command.PhoneNumber);
        }

        if (await _userRepository.GetUserByEmailAsync(command.Email) != null)
        {
            throw new EmailExistsException(command.Email);
        }
    }

    public async Task CustomLoginValidator(LoginQueries queries)
    {
        if (string.IsNullOrWhiteSpace(queries.Email))
        {
            throw new EmailEmptyException();
        }

        if (string.IsNullOrWhiteSpace(queries.Password))
        {
            throw new PasswordEmptyException();
        }

        var user = await _userRepository.CheckEmailLoginAsync(queries.Email);

        if (user is null)
        {
            throw new CheckEmailLoginException(queries.Email);
        }
    }

    public async Task CustomCreateProduct(CreateProductsCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.ProductName))
        {
            throw new FirstNameEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.Description))
        {
            throw new LastNameEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.SupplierId))
        {
            throw new EmailEmptyException();
        }

        if (string.IsNullOrWhiteSpace(command.PhoneNumber))
        {
            throw new PhoneNumberEmptyException();
        }

        if (command.Price == 0)
        {
            throw new GenderEmptyException();
        }

        if (command.ProductImage == null)
        {
            throw new PasswordEmptyException();
        }

        if (command.QuantityOnHand == 0)
        {
            throw new AddressEmptyException();
        }

        if (await _userRepository.GetUserByPhoneNumberAsync(command.PhoneNumber) != null)
        {
            throw new PhoneNumberExistsException(command.PhoneNumber);
        }
    }

    public async Task CustomCreateInventoryValidator(CreateInventoryCommand command)
    {
        var inventory = await _producerRespository.GetProductIdAsync(command.ProductId);

        if (inventory.Id == Guid.Empty)
        {
            throw new ProductIdEmptyException();
        }

        if (command.Quantity == 0)
        {
            throw new QuantityEmptyException();
        }

        if (command.LastRestockedDate == default)
        {
            throw new LastRestockedDateEmptyException();
        }
    }
}
