import axios from 'axios';

import { IParticipantDataService } from './participant.data-service.interface';
import { ParticipantModel } from '../models/participant.model';
import { IParticipantResponseModel } from '../response-models/participant.response-model.interface';

export class ParticipantDataService implements IParticipantDataService {

    private readonly endpoint: string = 'http://localhost:5000/api/participant';

    public async getAllAsync(): Promise<ParticipantModel[]> {
        const url = this.endpoint + '/getAll';

        try {
            const response = await axios.get<IParticipantResponseModel[]>(url);
            if (!response.data) {
                console.error(`No particiapnt data (response status = ${response.statusText})`);
                return [];
            }

            return response.data.map(dto => new ParticipantModel(dto));
        }
        catch (error) {
            console.error(error);
            return [];
        }
    }
}
