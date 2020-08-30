<template>
    <div id="app">
        <ParticipantList parent="App"/>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

import ParticipantList from './components/ParticipantList.vue';

@Component({
    components: {
        ParticipantList,
    },
})
export default class App extends Vue {}
</script>

<style>
#app {
    margin-top: 40px;
}
</style>
