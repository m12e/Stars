﻿using Altair.Core.DataServices.Interfaces;
using Altair.Core.Models;
using Altair.Dal.Contexts;
using Altair.Dal.DomainModels;
using AutoMapper;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using Stars.Dal.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Altair.Dal.DataServices
{
	public class ParticipantDataService : IParticipantDataService
	{
		private readonly IStarsLogger _logger;
		private readonly IMapper _mapper;
		private readonly IDomainRepository<ParticipantDomainModel> _repository;

		public ParticipantDataService(
			IStarsLogger logger,
			IMapper mapper,
			IDomainRepository<ParticipantDomainModel> repository)
		{
			_logger = logger;
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<ParticipantModel[]> GetAllAsync()
		{
			_logger.Debug("Getting all participants...");

			var participants = await _repository.GetAllAsync();
			var participantModels = _mapper.Map<ParticipantModel[]>(participants);

			_logger.Information($"All participants were successfully loaded and mapped (count = {participantModels.Length})");

			return participantModels;
		}

		public async Task<int> SaveAsync(ParticipantModel participantModel)
		{
			_logger.Debug($"Saving participant ({participantModel.ToJson()})...");

			var participant = _mapper.Map<ParticipantDomainModel>(participantModel);
			await _repository.SaveAsync(participant);

			_logger.Information($"Participant was successfully saved (id = {participant.Id})");

			return participant.Id;
		}
	}
}
