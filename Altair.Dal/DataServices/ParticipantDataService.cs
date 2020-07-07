using Altair.Core.DataServices.Interfaces;
using Altair.Core.Models;
using Altair.Dal.DomainModels;
using AutoMapper;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using Stars.Dal.EntityFramework.Repositories.Interfaces;
using Stars.Dal.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altair.Dal.DataServices
{
	public class ParticipantDataService : IParticipantDataService
	{
		private readonly IStarsLogger _logger;
		private readonly IMapper _mapper;
		private readonly IQueryableDomainRepository<ParticipantDomainModel> _repository;

		public ParticipantDataService(
			IStarsLogger logger,
			IMapper mapper,
			IQueryableDomainRepository<ParticipantDomainModel> repository)
		{
			_logger = logger;
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<int> GetCountAsync()
		{
			_logger.Information("Getting participant count...");

			var participantCount = await _repository.GetCountAsync();

			_logger.Information($"Participant count = {participantCount}");

			return participantCount;
		}

		public async Task<ParticipantModel> GetByIdAsync(int participantId)
		{
			_logger.Information($"Getting participant with id = {participantId}...");

			var participant = await _repository.GetByIdAsync(participantId);
			if (participant == null)
			{
				throw new DomainModelNotFoundException($"Participant with id = {participantId} was not found");
			}

			var participantModel = _mapper.Map<ParticipantModel>(participant);

			_logger.Information($"Participants with id = {participantId} was successfully loaded");

			return participantModel;
		}

		public async Task<ParticipantModel[]> GetAllAsync()
		{
			_logger.Information("Getting all participants...");

			var participants = await _repository.GetAllAsync();
			var participantModels = _mapper.Map<ParticipantModel[]>(participants);

			_logger.Information($"All participants were successfully loaded (count = {participantModels.Length})");

			return participantModels;
		}

		public async Task<int> SaveAsync(ParticipantModel participantModel)
		{
			_logger.Information($"Saving participant ({participantModel.ToJson()})...");

			var participant = _mapper.Map<ParticipantDomainModel>(participantModel);
			var wasRecordSaved = await _repository.SaveAsync(participant);
			if (!wasRecordSaved)
			{
				throw new DomainModelOperationException($"Error while saving participant");
			}

			_logger.Information($"Participant was successfully saved (id = {participant.Id})");

			return participant.Id;
		}

		public async Task<int> SaveListAsync(IEnumerable<ParticipantModel> participantModels)
		{
			_logger.Information($"Saving participants ({participantModels.ToJson()})...");

			var participants = _mapper.Map<ParticipantDomainModel[]>(participantModels);
			var recordCount = await _repository.SaveListAsync(participants);
			if (recordCount == 0)
			{
				throw new DomainModelOperationException($"Error while saving participant list");
			}

			_logger.Information($"Participants were successfully saved (count = {recordCount})");

			return recordCount;
		}

		public async Task UpdateAsync(ParticipantModel participantModel)
		{
			_logger.Information($"Updating participant ({participantModel.ToJson()})...");

			var participant = _mapper.Map<ParticipantDomainModel>(participantModel);
			var wasRecordUpdated = await _repository.UpdateAsync(participant);
			if (!wasRecordUpdated)
			{
				throw new DomainModelOperationException($"Error while updating participant with id = {participantModel.Id}");
			}

			_logger.Information($"Participant with id = {participantModel.Id} was successfully updated");
		}

		public async Task DeleteByIdAsync(int participantId)
		{
			_logger.Information($"Deleting participant with id = {participantId}...");

			var wasRecordDeleted = await _repository.DeleteByIdAsync(participantId);
			if (!wasRecordDeleted)
			{
				throw new DomainModelOperationException($"Error while deleting participant with id = {participantId}");
			}

			_logger.Information($"Participants with id = {participantId} was successfully deleted");
		}
	}
}
