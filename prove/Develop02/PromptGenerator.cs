class PromptGenerator 
{
    public List<string> _prompts = [
        // Self-Reflection
        "What are three qualities you love about yourself?",
        "What is something you're currently working to improve about yourself?",
        "How do you define success? Are you living in alignment with that definition?",
        "When was the last time you felt truly happy, and why?",
        "What are the most important lessons you've learned so far in life?",

        // Gratitude
        "What are five things you're grateful for today?",
        "Who has had the most positive impact on your life? Write about how they've influenced you.",
        "Write about a challenge you faced recently. How did it help you grow?",
        "Describe a moment where you felt connected to someone or something bigger than yourself.",
        "What is a small joy you experienced this week?",

        // Creativity & Future Dreams
        "If you could create your ideal day, what would it look like?",
        "Where do you see yourself in 5 years? In 10 years?",
        "What would you do if you knew you couldn't fail?",
        "If money were no object, how would you spend your time?",
        "What's a creative project you'd love to start?",

        // Emotions & Mindset
        "What's something you've been avoiding, and why?",
        "How do you process difficult emotions? What's one emotion you're feeling right now?",
        "Write about a time you overcame fear or anxiety. What did you learn from it?",
        "How do you define self-care, and what does it look like in your life?",
        "What are your biggest limiting beliefs? How can you challenge them?",

        // Relationships & Connection
        "Who do you trust the most, and what makes that relationship special?",
        "What's something you want to improve in your relationships?",
        "How do you show love to others? How do you prefer to receive love?",
        "Write a letter to someone you've lost contact with, expressing things left unsaid.",
        "Reflect on a time you experienced kindness from a stranger."
    ];

    public PromptGenerator() 
    {
        
    }

    public string GeneratePrompt() 
    {
        Random random = new();

        string prompt = _prompts[random.Next(0, _prompts.Count())];
        
        return prompt;
    }
}