<template>
    <div>
        <h1 class="header">Participant list</h1>
        <div class="info">
            <div>Parent: "{{ parent }}"</div>
            <div>Count: {{ participants.length }}</div>
        </div>
        <ul class="list">
            <li v-for="participant in participants" v-bind:key="participant.id">
                <div>{{ participant.fullName }} / {{ participant.age }} / {{ participant.personalCode }}</div>
            </li>
        </ul>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

import { ParticipantDataService } from '../data-services/participant.data-service';
import { IParticipantDataService } from '../data-services/participant.data-service.interface';
import { ParticipantViewModel } from '../view-models/participant.view-model';

@Component
export default class ParticipantList extends Vue {
    @Prop()
    private parent!: string;

    private participants: ParticipantViewModel[] = [];

    private participantDataService: IParticipantDataService = new ParticipantDataService();

    private async mounted(): Promise<void> {
        await this.initAsync();
    }

    private async initAsync(): Promise<void> {
        this.participants = (
            await this.participantDataService.getAllAsync()
        ).map((model, index) => new ParticipantViewModel(model, index));
    }
}
</script>

<style scoped>
.header {
    color: firebrick;
    margin-left: 10px;
}

.info {
    color: midnightblue;
    margin-left: 10px;
}

.list {
    color: darkslategrey;
    margin-left: 20px;
}
</style>
