<template>
  <v-container>
    <v-radio-group  v-model="radios" row>
      <v-radio label="すべて" value="0"></v-radio>
    </v-radio-group>
    <v-radio-group  v-model="radios" row>
      <v-radio label="フリー" value="1"></v-radio>
      <v-radio label="マイカー" value="2"></v-radio>
      <v-radio label="教育" value="3"></v-radio>
      <v-radio label="リフォーム" value="4"></v-radio>
      <v-radio label="カード" value="5"></v-radio>
    </v-radio-group>
  </v-container>
</template>

<script>
  export default {
    data () {
      return {
        radios: "0",
      }
    },
  }
</script>