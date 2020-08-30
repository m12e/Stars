import { IParticipantDataService } from './participant.data-service.interface';
import { ParticipantModel } from '../models/participant.model';
import { IParticipantResponseModel } from '../response-models/participant.response-model.interface';

export class ParticipantDataServiceMoq implements IParticipantDataService {

    private _participantListMoq: IParticipantResponseModel[] = [{
        lastName: 'Масловский',
        firstName: 'Еремей',
        patronymic: 'Сергеевич',
        age: 32,
        personalCode: 'MES-32'
    }, {
        lastName: 'Муравьёв',
        firstName: 'Устин',
        patronymic: 'Юхимович',
        age: 44,
        personalCode: 'MUYU-44'
    }, {
        lastName: 'Дидовец',
        firstName: 'Йомер',
        patronymic: 'Иванович',
        age: 27,
        personalCode: 'DYOI-27'
    }];

    public async getAllAsync(): Promise<ParticipantModel[]> {
        return this._participantListMoq.map(dto => new ParticipantModel(dto));
    }
}
