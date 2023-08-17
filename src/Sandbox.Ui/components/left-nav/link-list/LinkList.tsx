import { LineChartOutlined, SettingOutlined, ThunderboltOutlined } from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Menu } from 'antd';
import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import AppContext from '../../../AppContext';
import './LinkList.scss';
import { LinkListProps } from './LinkListProps';

type MenuItem = Required<MenuProps>['items'][number];

/**
 * Defines the user card component.
 */
const LinkList: React.FunctionComponent<LinkListProps> = (props: LinkListProps) => {
    const {selectedMenuItem} = useContext(AppContext);
    const {setSelectedMenuItem} = useContext(AppContext);
    const items: MenuItem[] = [
        getItem(<Link onClick={() => setSelectedMenuItem('dashboard')} to="/dashboard">Dashboard</Link>,
                'dashboard', <LineChartOutlined />),
        getItem(<Link onClick={() => setSelectedMenuItem('workflows')} to="/workflows">Workflows</Link>,
                'workflows', <ThunderboltOutlined />),
        getItem(<Link onClick={() => setSelectedMenuItem('settings')} to="/settings">Settings</Link>,
                'settings', <SettingOutlined />)
        ];
        
    /**
     * Renders the user card component.
     * @returns The user card component.
     * @override
     */
    
        
        return (
            <Menu className="link-list"
                mode="vertical"
                items={items}
                defaultSelectedKeys={[selectedMenuItem]}
            />
        );
     function getItem(
        label: React.ReactNode,
        key: React.Key,
        icon?: React.ReactNode,
        children?: MenuItem[],
        type?: 'group',
    ): MenuItem {
        return {
            key,
            icon,
            children,
            label,
            type,
        } as MenuItem;
    }
}

export default LinkList;