import React, {useState} from 'react';
import styles from './NavBar.module.css'
import {Col, Row} from "antd";
import {
    BankOutlined,
    CalendarOutlined,
    CarryOutOutlined,
    DesktopOutlined, FileOutlined,
    HomeOutlined,
    PieChartOutlined,
    ShopOutlined, StockOutlined, TeamOutlined, UserOutlined
} from "@ant-design/icons";
import type { MenuProps } from 'antd';
import { Breadcrumb, Layout, Menu, theme } from 'antd';
const { Header, Content, Footer, Sider } = Layout;

type MenuItem = Required<MenuProps>['items'][number];


function getItem(
    label: React.ReactNode,
    key: React.Key,
    icon?: React.ReactNode,
    children?: MenuItem[],
): MenuItem {
    return {
        key,
        icon,
        children,
        label,
    } as MenuItem;
}

const items: MenuItem[] = [
    getItem('Личный кабинет','1', <HomeOutlined/>),
    getItem('Мероприятия', '2', <CalendarOutlined />),
    getItem('Рейтинг студентов', 'sub1', <StockOutlined />),
    getItem('Магазин купонов', 'sub2', <BankOutlined />),
];

interface NavBarProps {
    children:JSX.Element;
}

const NavBar: React.FC<NavBarProps> = ({children}) => {

    const [collapsed, setCollapsed] = useState(false);
    const {
        token: { colorBgContainer, borderRadiusLG },
    } = theme.useToken();


    return (
        <Layout style={{ minHeight: '100vh', marginRight: '10px'}}>
            <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
                <div className="demo-logo-vertical" />
                <Menu className={styles.menu} theme="dark" defaultSelectedKeys={['1']} mode="inline" items={items} />
            </Sider>
            <Layout className={styles.padLayout}>
                {children}
            </Layout>
        </Layout>
    );
};

export default NavBar;