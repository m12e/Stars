import { ParticipantModel } from '../models/participant.model';

export interface IParticipantDataService {

    getAllAsync(): Promise<ParticipantModel[]>;
}
