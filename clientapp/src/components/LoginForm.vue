<template>
  <v-layout align-center justify-center>
    <v-flex xs10 sm8 md4>
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
          <v-spacer></v-spacer>
          <v-btn color="teal">Sign up</v-btn>
          <v-btn color="red">
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

export default Vue.extend({});
</script>