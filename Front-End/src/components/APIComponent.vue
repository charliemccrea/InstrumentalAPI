<template>
  <v-container>
    <v-layout
      align-center
      justify-center
      text-center
      wrap
    >
      <div class="align-center justify-center">

        <v-dialog v-model="dialogADD" max-width="600px">
          <template v-slot:activator="{ on }">
            <v-btn color="secondary" class="ma-2" dark v-on="on">
              <span class="hidden-sm-and-down">Add</span>
              <v-icon right>mdi-plus-box</v-icon>
            </v-btn>
          </template>
          <form>
            <v-card>
              <v-card-title>
                <span class="headline">Add Instrument</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field
                        v-model="formINST"
                        :counter="20"
                        label="Instrument Name*"
                        data-vv-name="formINST"
                        required>
                      </v-text-field>
                    </v-col>
                    <v-col cols="12" sm="6">
                      <v-select
                        v-model="formCAT"
                        :items="formLIST"
                        label="Category*"
                        data-vv-name="select"
                        required>
                      </v-select>
                    </v-col>
                  </v-row>
                </v-container>
                <small>*indicates required field</small>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialogADD = false">Cancel</v-btn>
                <v-btn color="blue darken-1" text class="mr-4" @click="submitADD">Submit</v-btn>
              </v-card-actions>
            </v-card>
          </form>
        </v-dialog>
        
        <v-btn value="left" class="ma-2" color="secondary" v-on:click="getData">
          <span class="hidden-sm-and-down">Update</span>
          <v-icon right>mdi-refresh</v-icon>
        </v-btn>

        <v-dialog v-model="dialogREP" max-width="600px">
          <template v-slot:activator="{ on }">
            <v-btn color="secondary" class="ma-2" dark v-on="on">
              <span class="hidden-sm-and-down">Replace</span>
              <v-icon right>mdi-swap-horizontal</v-icon>
            </v-btn>
          </template>
          <form>
            <v-card>
              <v-card-title>
                <span class="headline">Replace Instrument</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field
                        v-model="formINST"
                        :counter="20"
                        label="Instrument Name*"
                        data-vv-name="formINST"
                        required>
                      </v-text-field>
                    </v-col>
                    <v-col cols="12" sm="6">
                      <v-select
                        v-model="formCAT"
                        :items="formLIST"
                        label="Category*"
                        data-vv-name="select"
                        required>
                      </v-select>
                      <v-text-field
                        v-model="formID"
                        label="Instrument Id*"
                        data-vv-name="formID"
                        required>
                      </v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
                <small>*indicates required field</small>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialogREP = false">Cancel</v-btn>
                <v-btn color="blue darken-1" text class="mr-4" @click="submitREP">Submit</v-btn>
              </v-card-actions>
            </v-card>
          </form>
        </v-dialog>

        <v-dialog v-model="dialogDEL" max-width="600px">
          <template v-slot:activator="{ on }">
            <v-btn color="secondary" class="ma-2" dark v-on="on">
              <span class="hidden-sm-and-down">Delete</span>
              <v-icon right>mdi-delete</v-icon>
            </v-btn>
          </template>
          <form>
            <v-card>
              <v-card-title>
                <span class="headline">Delete Instrument</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field
                        v-model="formID"
                        label="Instrument Id*"
                        data-vv-name="formID"
                        required>
                      </v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
                <small>*indicates required field</small>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialogDEL = false">Cancel</v-btn>
                <v-btn color="blue darken-1" text class="mr-4" @click="submitDEL">Submit</v-btn>
              </v-card-actions>
            </v-card>
          </form>
        </v-dialog>

        <v-simple-table class="ma-2" align="center" justify="center" >
          <template v-slot:default>
            <thead>
              <tr>
                <th class="text-left">ID</th>
                <th class="text-left">Instrument Name</th>
                <th class="text-right">Category</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in instruments" :key="item.id">
                <td class="text-left">{{ item.id }}</td>
                <td class="text-left">{{ item.itemName }}</td>
                <td class="text-right">{{ item.category }}</td>
              </tr>
            </tbody>
          </template>
        </v-simple-table>

        <v-snackbar v-model="snackbarON" :timeout="snackbarTIMEOUT">
          {{ snackbarTEXT }}
          <v-btn color="primary" text @click="snackbarON = false">
            Close
          </v-btn>
        </v-snackbar>

      </div>
    </v-layout>
  </v-container>
</template>

<script>
import axios from 'axios'

export default {
  name: 'APIComponent',

  data () {
    return {
      formINST: '',
      formCAT: null,
      formLIST: [ 'Percussion', 'Wind', 'Stringed', 'Electronic', 'Other', ],
      formID: null,
      usableINST: null,
      usableCAT: null,
      usableID: null,
      snackbarON: false,
      snackbarTEXT: '',
      snackbarTIMEOUT: 8000,
      dialogADD: false,
      dialogREP: false,
      dialogDEL: false,
      instruments: null,
      address: 'https://localhost:44307/api/Instruments'
    }
  },

  mounted () {
    this.getData()
  },

  updated () {
    this.getData()
  },

  methods: {

    submitADD () {
      this.usableINST = this.formINST
      this.usableCAT = this.formCAT
      this.dialogADD = false
      this.postData()
      this.snackbarTEXT = 'Instrument added.'
      this.snackbarON = true
    },

    submitREP () {
      this.usableINST = this.formINST
      this.usableCAT = this.formCAT
      this.usableID = this.formID
      this.dialogREP = false
      this.putData()
      this.snackbarTEXT = 'Instrument replaced.'
      this.snackbarON = true
    },

    submitDEL () {
      this.usableID = this.formID
      this.dialogDEL = false
      this.deleteData()
      this.snackbarTEXT = 'Instrument deleted.'
      this.snackbarON = true
    },

    getData () {
      axios
      .get(this.address)
      .then(response => {
        this.instruments = response.data
      })
      .catch(e => { // eslint-disable-line no-unused-vars
      })
    },

    postData () {
      axios
      .post(this.address, {ItemName: this.usableINST, Category: this.usableCAT})
      .then(response => { // eslint-disable-line no-unused-vars
        this.getData()
      })
      .catch(e => {
        this.snackbarTEXT = e.response.data
        this.snackbarON = true
      })
    },

    putData () {
      axios
      .put(this.address + "/" + Number(this.usableID), {ItemName: this.usableINST, Category: this.usableCAT})
      .then(response => { // eslint-disable-line no-unused-vars
        this.getData()
      })
      .catch(e => {
        this.snackbarTEXT = e.response.data
        this.snackbarON = true
      })
    },

    deleteData () {
      axios
      .delete(this.address + "/" + Number(this.usableID))
      .then(response => { // eslint-disable-line no-unused-vars
        this.getData()
      })
      .catch(e => {
        this.snackbarTEXT = e.response.data
        this.snackbarON = true
      })
    }

  }
};
</script>
