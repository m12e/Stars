import { IParticipantResponseModel } from '../response-models/participant.response-model.interface';

export class ParticipantModel {

    public lastName: string;
    public firstName: string;
    public patronymic: string;
    public age: number;
    public personalCode: string;

    constructor(dto: IParticipantResponseModel) {
        this.lastName = dto.lastName;
        this.firstName = dto.firstName;
        this.patronymic = dto.patronymic;
        this.age = dto.age;
        this.personalCode = dto.personalCode;
    }
}
