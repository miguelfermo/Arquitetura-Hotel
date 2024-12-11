# 🏨 | Arquitetura em Microsserviços de um Hotel
Arquitetura de Software - Sistema de Reserva de Quartos de Hotel

# 📖 | Documento de Requisitos - Sistema de Reserva de Quartos de Hotel
Documentação sobre o projeto.

## 🎯 A. Propósito do Sistema
O sistema de Reserva de Quartos de Hotel tem como objetivo gerenciar as reservas, disponibilidades e informações dos quartos, além de manter o cadastro de hóspedes. O sistema permite que os administradores do hotel verifiquem a disponibilidade de quartos, realizem reservas, registrem hóspedes e atualizem dados de forma eficiente e integrada, otimizando a operação e a organização das estadias.

## 🤵🏽 B. Usuários
- **Administradores do Hotel**: Funcionários que gerenciam reservas, quartos e o cadastro de hóspedes.
- **Recepcionistas**: Funcionários que fazem consultas de disponibilidade e registram reservas e cancelamentos.
- **Gerentes**: Usuários com permissão para consultar relatórios de ocupação, histórico de hóspedes e status financeiro dos quartos e reservas.

## 🧠 C. Requisitos Funcionais

### Gestão de Quartos
- O sistema deve permitir o cadastro, consulta e atualização das informações dos quartos, incluindo tipo, preço e status de disponibilidade.
- O sistema deve permitir que o status de um quarto seja atualizado automaticamente ao realizar uma reserva ou um cancelamento.

### Gestão de Reservas
- O sistema deve permitir a criação de uma nova reserva com base na disponibilidade dos quartos.
- O sistema deve permitir o cancelamento de reservas, atualizando o status de disponibilidade do quarto correspondente.
- O sistema deve permitir consultar o histórico de reservas dos hóspedes.

### Gestão de Hóspedes
- O sistema deve permitir o cadastro de novos hóspedes com informações pessoais.
- O sistema deve permitir a consulta dos dados de hóspedes, incluindo histórico de estadias e status (VIP, inadimplente, etc.).

### Integrações entre Microsserviços
- O sistema de Reservas deve consultar o serviço de Quartos para verificar a disponibilidade antes de registrar uma nova reserva.
- O sistema de Reservas deve consultar o serviço de Hóspedes para verificar o cadastro e o status de um hóspede antes de associá-lo a uma nova reserva.
- O sistema de Reservas deve notificar o serviço de Quartos para atualizar o status de disponibilidade quando uma reserva for cancelada.

## 🔧 Instalação:
- Clone esse repositório com `git clone` ou baixe o código-fonte.

## 👷🏽 Desenvolvedores:
- [Miguel Fermo](https://github.com/miguelfermo)
- [Alexandre Destro](https://github.com/AlexandreDestro)
