using AutoMapper;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Cliente;
using Layer.Architecture.Infra.Data.Interface;
using Layer.Architecture.Service.Interface;
using Layer.Architecture.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository ClienteRepository, IMapper mapper)
        {
            _ClienteRepository = ClienteRepository;
            _mapper = mapper;

        }


        public async Task Add(CreateClienteVM inputModel)
        {
            try
            {
                var entity = _mapper.Map<Cliente>(inputModel);

                Validate(entity, Activator.CreateInstance<ClienteValidator>());
                var ret = await _ClienteRepository.Insert(entity);
            }
            catch(AggregateException ex)
            {
                throw new AggregateException( ex.Message );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id) => await _ClienteRepository.Delete(id);

        public async Task<IEnumerable<ClienteVM>> Get()
        {
            var entities = await _ClienteRepository.Select();

            var outputModels = entities.Select(s => _mapper.Map<ClienteVM>(s));

            return outputModels;
        }

        public async Task<ClienteVM> GetById(int id)
        {
            var entity = await _ClienteRepository.Select(id);

            var outputModel = _mapper.Map<ClienteVM>(entity);

            return outputModel;
        }

        public async Task Update(ClienteVM inputModel)
        {
            var entity = _mapper.Map<Cliente>(inputModel);
            var ClienteDB = await _ClienteRepository.Select(inputModel.Id);
            if (ClienteDB == null)
            {
                throw new Exception("Cliente Inválido");
            };
            Validate(entity, Activator.CreateInstance<ClienteValidator>());
            await _ClienteRepository.Update(entity);
        }
    }
}
