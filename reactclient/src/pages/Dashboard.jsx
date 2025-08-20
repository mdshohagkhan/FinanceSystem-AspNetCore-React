import React, { useEffect, useState } from 'react';
import { Container, Row, Col, Card, Button, Nav } from 'react-bootstrap';
import { useNavigate, Link } from 'react-router-dom';
import { useAuth } from '../hooks/useAuth';
import api from '../services/api';
import './Dashboard.css'; 

const Dashboard = () => {
  const { user } = useAuth();
  const navigate = useNavigate();
  const [stats, setStats] = useState({ clients: 0, projects: 0, invoices: 0, accounts: 0, revenue: 0 });

  useEffect(() => {
    const fetchStats = async () => {
      try {
        const [clientsRes, projectsRes, invoicesRes, accountsRes] = await Promise.all([
          api.get('/Clients'),
          api.get('/Projects'),
          api.get('/Invoices'),
          api.get('/Accounts')
        ]);

        const revenue = invoicesRes.data.reduce((sum, inv) => sum + (inv.amount || 0), 0);

        setStats({
          clients: clientsRes.data.length,
          projects: projectsRes.data.length,
          invoices: invoicesRes.data.length,
          accounts: accountsRes.data.length,
          revenue
        });
      } catch (err) {
        console.error('Failed to fetch stats:', err);
      }
    };

    fetchStats();
  }, []);

  const cards = [
    { title: 'Clients', value: stats.clients, icon: 'fas fa-users', colorClass: 'card-clients', route: '/clients' },
    { title: 'Projects', value: stats.projects, icon: 'fas fa-project-diagram', colorClass: 'card-projects', route: '/projects' },
    { title: 'Invoices', value: stats.invoices, icon: 'fas fa-file-invoice-dollar', colorClass: 'card-invoices', route: '/invoices' },
    { title: 'Accounts', value: stats.accounts, icon: 'fas fa-wallet', colorClass: 'card-accounts', route: '/accounts' },
    { title: 'Revenue', value: `$${stats.revenue.toFixed(2)}`, icon: 'fas fa-chart-line', colorClass: 'card-revenue', route: '/reports' }
  ];

  return (
    <Container className="dashboard-container">
      <h1 className="dashboard-header text-center">Welcome, {user.email}!</h1>

      <Nav className="dashboard-nav justify-content-center mb-5" variant="pills" defaultActiveKey="/clients">
        <Nav.Item>
          <Nav.Link as={Link} to="/clients">Clients</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link as={Link} to="/projects">Projects</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link as={Link} to="/accounts">Accounts</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link as={Link} to="/invoices">Invoices</Nav.Link>
        </Nav.Item>
      </Nav>

      <Row className="dashboard-cards-row">
        {cards.map((card, idx) => (
          <Col md={6} lg={3} key={idx} className="mb-4">
            <Card
              className={`dashboard-card ${card.colorClass}`}
              onClick={() => navigate(card.route)}
            >
              <Card.Body className="d-flex align-items-center">
                <div className="card-icon-wrapper me-3">
                  <i className={`card-icon ${card.icon}`}></i>
                </div>
                <div className="card-content">
                  <Card.Title className="card-title">{card.title}</Card.Title>
                  <Card.Text className="card-value">{card.value}</Card.Text>
                </div>
              </Card.Body>
            </Card>
          </Col>
        ))}
      </Row>

      <Card className="dashboard-quick-actions shadow-sm">
        <Card.Body>
          <h4 className="quick-actions-title">Overview & Quick Actions</h4>
          <p className="quick-actions-description">
            This page provides a quick snapshot of your system. Click any card above to view details or manage records.
          </p>
          <div className="d-flex flex-wrap gap-2">
            <Button variant="primary" onClick={() => navigate('/clients')}>Manage Clients</Button>
            <Button variant="success" onClick={() => navigate('/projects')}>Manage Projects</Button>
            <Button variant="warning" onClick={() => navigate('/invoices')}>Manage Invoices</Button>
            <Button variant="info" onClick={() => navigate('/accounts')}>Manage Accounts</Button>
          </div>
        </Card.Body>
      </Card>
    </Container>
  );
};

export default Dashboard;