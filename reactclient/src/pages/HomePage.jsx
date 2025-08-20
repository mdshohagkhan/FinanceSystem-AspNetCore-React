// src/pages/HomePage.jsx

import React from 'react';
import { Link } from 'react-router-dom';
import { Container, Button, Row, Col } from 'react-bootstrap';
import './HomePage.css';

const HomePage = () => {
  const items = [
    { label: 'Clients', value: '158+' },
    { label: 'Projects', value: '92' },
    { label: 'Invoices', value: '134' },
    { label: 'Backend', value: 'ASP.NET Core Web API, Entity Framework' },
    { label: 'Database', value: 'SQL Server' },
    { label: 'Frontend', value: 'React.js, React-Bootstrap, React Router' },
  ];

  return (
    <div className="hero-section-advanced">
      <Container className="hero-content-advanced text-white text-center">
        <h1 className="hero-title-advanced">Smart Financial System</h1>
        <p className="hero-subtitle-advanced">
          Manage your clients, projects, invoices & accounts—seamlessly & effectively.
        </p>
        <Link to="/dashboard">
          <Button variant="warning" size="lg" className="hero-btn-advanced mb-5">
            Go to Dashboard
          </Button>
        </Link>

        <Row className="justify-content-center stats-tech-row mt-4">
          {items.map((item, idx) => (
            <Col xs={6} md={3} key={idx} className="stat-tech-card-advanced">
              <h4>{item.value}</h4>
              <p>{item.label}</p>
            </Col>
          ))}
        </Row>
      </Container>
    </div>
  );
};

export default HomePage;
