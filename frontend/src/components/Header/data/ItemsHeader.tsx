import { AppRouterInstance } from 'next/dist/shared/lib/app-router-context.shared-runtime';
import { MenuItem } from 'primereact/menuitem';

interface CustomMenuItem extends MenuItem {
    badge?: number;
}

export const createItemsHeader = (router : AppRouterInstance): CustomMenuItem[] => [
    {
        label: 'Início',
        icon: 'pi pi-home',
        command: () => router.push('/home'),
    },
    {
        label: 'Usuários',
        icon: 'pi pi-users',
        command: () => router.push('/users'),
    }
];

export default createItemsHeader; 