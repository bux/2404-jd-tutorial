<script setup lang="ts">
import Messages from '@/components/Messages.vue'
import PromptInput from '@/components/PromptInput.vue'
import { useChat } from '@/composables/useChat'

const { messages, sendMessage } = useChat()

async function promptEntered(text: string) {
  await sendMessage(text)
}
</script>

<template>
  <main>
    <Messages :messages="messages" />
    <PromptInput @prompt-entered="promptEntered" />
  </main>
</template>

<style scoped>
main {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}
</style>
