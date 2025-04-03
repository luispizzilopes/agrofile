export default function getAllErrorMessages(errors: any) {
    let messages: any[] = [];

    if (errors && Object.keys(errors).length > 0) {
        Object.keys(errors).forEach(key => {
            if (Array.isArray(errors[key])) {
                messages = messages.concat(errors[key]);
            } else if (typeof errors[key] === 'string') {
                messages.push(errors[key]);
            }
        });
    }

    return messages;
}

