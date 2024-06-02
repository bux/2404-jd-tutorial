<script setup lang="ts">
import type { ChatMessage } from '@/composables/useChat'

interface Props {
    message: ChatMessage
}
defineProps<Props>()
</script>

<template>
    <p>{{ message.text }}</p>
</template>
