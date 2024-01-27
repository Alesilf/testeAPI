using AutoMapper;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Parcela;
using Layer.Architecture.Infra.Data.Interface;
using Layer.Architecture.Infra.Data.Repository;
using Layer.Architecture.Service.Interface;
using Layer.Architecture.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Services
{
    public class ParcelaService : BaseService<Parcela>, IParcelaService
    {
        private readonly IParcelaRepository _parcelaRepository;
        private readonly IMapper _mapper;

        public ParcelaService(IParcelaRepository ParcelaRepository, IMapper mapper)
        {
            _parcelaRepository = ParcelaRepository;
            _mapper = mapper;

        }


        public async Task Add(CreateParcelaVM inputModel)
        {
            var entity = _mapper.Map<Parcela>(inputModel);

            Validate(entity, Activator.CreateInstance<ParcelaValidator>());
            await _parcelaRepository.Insert(entity);
        }

        public async Task Delete(int id) => await _parcelaRepository.Delete(id);

        public async Task<IEnumerable<ParcelaVM>> Get()
        {
            var entities = await _parcelaRepository.Select();

            var outputModels = entities.Select(s => _mapper.Map<ParcelaVM>(s));

            return outputModels;
        }

        public async Task<ParcelaVM> GetById(int id)
        {
            var entity = await _parcelaRepository.Select(id);

            var outputModel = _mapper.Map<ParcelaVM>(entity);

            return outputModel;
        }

        public async Task Update(ParcelaVM inputModel)
        {
            var entity = _mapper.Map<Parcela>(inputModel);
            var parcelaDB = await _parcelaRepository.Select(inputModel.Id);
            if (parcelaDB == null) 
            { 
                throw new Exception("Parcela Inválida"); 
            };
            Validate(entity, Activator.CreateInstance<ParcelaValidator>());
            await _parcelaRepository.Update(entity);
        }
    }
}
