using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using System;
using System.Threading.Tasks;

namespace BAL.Services
{
    public abstract class Service<TEntity, TDto> : IService<TDto>
        where TEntity : class, Models.Entities.IEntity, new()
    {

        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> _repository;
        protected readonly IQuery<TEntity> _query;
        protected readonly ILogger<TEntity> _logger;

        protected Service(
            IMapper mapper, 
            IRepository<TEntity> repository,
            IQuery<TEntity> query,
            ILogger<TEntity> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _query = query ?? throw new ArgumentNullException(nameof(query));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public virtual async Task<Guid> CreateAsync(TDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repository.CreateAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(Guid entityID)
        {
            await _repository.DeleteAsync(entityID);
        }

        public virtual async Task<TDto> GetAsync(Guid entityId)
        {
            var entity = await _repository.GetAsync(entityId);
            var result = _mapper.Map<TDto>(entity);
            return result;
        }

        public virtual async Task UpdateAsync(DTO entityDto)
        {
            var entity = await _repository.GetAsync(entityDto.Id);
            await _repository.UpdateAsync(_mapper.Map<TEntity>(entity));
        }
    }
}
