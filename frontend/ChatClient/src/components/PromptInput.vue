<script setup lang="ts">
import { ref } from 'vue'

const emit = defineEmits<{
  (e: 'prompt-entered', text: string): any
}>()

const input = ref('')
function promptEntered() {
  if (!input.value) return
  emit('prompt-entered', input.value)
  input.value = ''
}
</script>

<template>
  <form @submit.prevent="promptEntered">
    <input type="text" v-model="input" placeholder="Send a message" />
    <button type="submit">Submit</button>
  </form>
</template>

<style scoped>
form {
  display: flex;
  justify-content: center;
  gap: 1rem;
  padding: 2rem 1rem;
}

input, button {
  border: 1px solid #ccc;
  border-radius: 0.5rem;
  padding: 0.5rem 1rem;
  color: #fff;
  font-size: 1.125rem;

}

input {
  background-color: transparent;
}

button {
  background-color: #333;
  cursor: pointer;
}
</style>
