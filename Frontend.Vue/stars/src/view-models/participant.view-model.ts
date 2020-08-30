import { ParticipantModel } from '../models/participant.model';

export class ParticipantViewModel {

    public id: number;
    public fullName: string;
    public age: number;
    public personalCode: string;

    constructor(model: ParticipantModel, id: number = 0) {
        this.fullName = `${model.lastName} ${model.firstName} ${model.patronymic}`;
        this.age = model.age;
        this.personalCode = model.personalCode;
        this.id = id;
    }
}
