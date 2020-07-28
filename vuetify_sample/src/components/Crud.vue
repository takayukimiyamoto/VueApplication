<template>
  <v-container >
    <div class="px-4 pt-4 pb-3 v-sheet theme--light rounded-0">
      <div class="transition-swing text-h4">金利</div>
    </div>
    <v-data-table
      :headers="headers"
      :items="filter"
      hide-default-footer
      class="elevation-1"
    >
      <template v-slot:top>
        <v-container >
        <v-toolbar flat height="120px" color="white">
          <div>
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
          </div>
          <v-spacer></v-spacer>
          <v-btn
            color="primary"
            dark
            class="mb-2"
            to="/detail/guid"
            large
          >新規作成</v-btn>
        </v-toolbar>
        </v-container >
      </template>
      <template v-slot:item.actions="{ item }">
         <v-btn
          to="/detail/guid"
          color="secondary"
          dark
          class="mb-2"
          @click="editItem(item)"
          small
        >詳細</v-btn>
      </template>
    </v-data-table>
  </v-container>
</template>

<script>
  const headers = [
    {
      text: '種別',
      align: 'start',
      value: 'name',
      width: '25%'
    },
    { text: '開始日', value: 'start', width: '25%' },
    { text: '終了日', value: 'end', width: '25%' },
    { value: 'actions', sortable: false, width: '25%' },
  ];

  const items = [
    {
      type: "2",
      name: 'マイカー',
      start: '2020-01-01',
      end: '2020-01-01',
    },
    {
      type: "2",
      name: 'マイカー',
      start: '2020-01-02',
      end: '2020-01-31',
    },
    {
      type: "5",
      name: 'カード',
      start: '2020-01-01',
      end: '2020-01-01',
    }
  ];

  export default {
    data: () => ({
      dialog: false,
      headers: headers,
      items: items,
      editedIndex: -1,
      editedItem: {
        name: '',
        start: 0,
        end: 0,
      },
      defaultItem: {
        name: '',
        start: 0,
        end: 0,
      },
      radios: "0",
    }),
    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
      },
      filter () {
        if (this.radios === "0") {
          return this.items;
        } else {
          const type = this.radios;
          return this.items.filter(item => item.type === type);
        }
      }
    },
    watch: {
      dialog (val) {
        val || this.close()
      },
    },
    methods: {
      editItem (item) {
        this.editedIndex = this.items.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },
      deleteItem (item) {
        const index = this.items.indexOf(item)
        confirm('Are you sure you want to delete this item?') && this.items.splice(index, 1)
      },
      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },
      save () {
        if (this.editedIndex > -1) {
          Object.assign(this.items[this.editedIndex], this.editedItem)
        } else {
          this.items.push(this.editedItem)
        }
        this.close()
      },
    },
  }
</script>