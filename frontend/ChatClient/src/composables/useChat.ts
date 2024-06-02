import { ref } from 'vue';

export interface ChatMessage {
    id: number;
    text: string;
    sender: 'User' | 'Bot';
    timestamp: string;
}


export function useChat() {
    const url: string = "http://localhost:8080/messages";
    const messages = ref<Array<ChatMessage>>([]);

    async function sendMessage(text: string) {
        addMessage({
            id: messages.value.length + 1,
            text: text,
            sender: 'User',
            timestamp: new Date().toLocaleTimeString(),
        });

        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ content: text }),
        })
        const data = await response.text()

        addMessage({
            id: messages.value.length + 1,
            text: data,
            sender: 'Bot',
            timestamp: new Date().toLocaleTimeString(),
        });
    }

    function addMessage(message: ChatMessage) {
        messages.value = [...messages.value, message];
    }

    return {
        messages,
        sendMessage,
    };
}