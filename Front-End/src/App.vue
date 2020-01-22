<template>
  <v-app>
    <v-app-bar
      app
      color="secondary"
      dark
    >
      <div class="d-flex align-center">
        <v-img
          alt="InstrumentalAPI Logo"
          class="shrink mr-2"
          contain
          src="./assets/logo.png"
          transition="scale-transition"
          width="40"
        />

        <h2>
          InstrumentalAPI
        </h2>
      </div>

      <v-spacer></v-spacer>

      <v-btn
        href="https://github.com/"
        target="_blank"
        text
      >
        <span class="mr-2">Source</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
    </v-app-bar>

    <v-content>
      <MainComponent/>
      <APIComponent/>
    </v-content>
  </v-app>
</template>

<script>
import MainComponent from './components/MainComponent';
import APIComponent from './components/APIComponent';

export default {
  name: 'App',

  components: {
    MainComponent,
    APIComponent,
  },

  data: () => ({
    //
  }),
};
</script>
