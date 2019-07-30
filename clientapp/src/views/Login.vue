<template>
  <v-layout align-center justify-center>
    <v-flex xs11 sm9 md7 lg5 xl3>
      <v-card class="elevation-12">
        <v-toolbar dark flat>
          <v-toolbar-title>
            <v-icon>event_available</v-icon>&nbsp;Welcome to Attendance Manager&trade;
          </v-toolbar-title>
          <v-spacer></v-spacer>
        </v-toolbar>
        <v-card-text>
          <v-text-field label="Mail Address" prepend-icon="person" type="text"></v-text-field>
          <v-text-field label="Password" prepend-icon="lock" type="password"></v-text-field>
        </v-card-text>
        <v-card-actions>
          <v-checkbox v-model="isRememberMe" label="Remember me"></v-checkbox>
          <v-spacer></v-spacer>
          <v-btn color="teal">Sign up</v-btn>
          <v-btn color="error">
            Sign in&nbsp;
            <v-icon>touch_app</v-icon>
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script lang="ts">
import Vue from "vue";
import fetch from "isomorphic-fetch";

namespace AttendanceManager {
  export class LoginMain {
    isRememberMe: boolean;

    constructor() {
      this.isRememberMe = true;
    }

    initialize(): void {
      fetch("/api/hello/getIsRememberMe", {
        method: "Post",
        credentials: "same-origin"
      })
        .then(response => {
          return response.json();
        })
        .then((result: boolean) => {
          this.isRememberMe = result;
        });
    }
  }
}

let vm = new AttendanceManager.LoginMain();
export default Vue.extend({
  data: () => vm,
  mounted() {
    vm.initialize();
  }
});
</script>