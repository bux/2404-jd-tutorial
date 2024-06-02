<script setup lang="ts">
import type { ChatMessage } from '@/composables/useChat'
import Message from '@/components/Message.vue'

interface Props {
    messages: ChatMessage[]
}
defineProps<Props>()
</script>

<template>
    <section>
        <ol>
            <li v-for="message in messages" :key="message.id" :class="{'user': message.sender == 'User'}">
                <Message :message="message" />
            </li>
        </ol>
    </section>
</template>

<style scoped>
section {
    flex: 1;
    padding: 2rem 4rem;
}

ol {
    list-style-type: none;
    display: flex;
    flex-direction: column;
    gap: 2rem;

    & .user {
        max-width: 65%;
        align-self: flex-end;
        padding: 0.5rem 1rem;
        border-radius: 0.5rem;
        background: #333;
    }
}
</style>
