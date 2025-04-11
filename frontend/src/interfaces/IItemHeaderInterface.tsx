export default interface IItemHeaderInterface{
    label: string, 
    icon: any, 
    items: IItemHeaderInterface[], 
    shortcut: string, 
    visible: boolean, 
    action: () => void, 
    badge?: number | null, 
}