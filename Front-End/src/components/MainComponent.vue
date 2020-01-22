<template>
  <v-container>
    <v-layout
      align-center
      justify-center
      text-center
      wrap
    >
      <v-flex xs12>
        <v-img
          :src="require('../assets/logo.svg')"
          class="my-3"
          contain
          height="200"
        ></v-img>
      </v-flex>

      <v-flex mb-4>
        <h1 class="display-2 font-weight-bold mb-3">
          Welcome to InstrumentalAPI
        </h1>
        <p class="subheading font-weight-regular">
          This Web App was designed as practice for interacting with an ASP.NET Core API using VUE.js as a front-end interface.
          <br>It involves adding various musical instruments to an in-memory sql database using HTTP requests.
        </p>
        
        <v-card class="mx-auto" max-width="344">
          <v-card-text>
            <div>Implemented Requests</div>
            <p></p>
            <div class="text--primary">
              Add (HttpPost)<br>
              Update (HttpGet)<br>
              Replace (HttpPut)<br>
              Delete (HttpDelete)<br>
            </div>
          </v-card-text>
        </v-card>
      </v-flex>

    </v-layout>
  </v-container>
</template>
