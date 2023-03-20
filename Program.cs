using Apache.NMS;
using Apache.NMS.ActiveMQ;

var factory = new ConnectionFactory("tcp://localhost:61616");

// Create a connection
using (var connection = factory.CreateConnection("admin", "admin"))
{
    // Start the connection
    connection.Start();

    // Create a session
    using var session = connection.CreateSession();

    // Create a destination (queue or topic)
    var destination = session.GetQueue("testqueue");

    SendMessage(session, destination);
    
    ReceiveMessage(session, destination);

    connection.Stop();
}

static void SendMessage(ISession session, IQueue destination)
{
    // Create a producer
    var producer = session.CreateProducer(destination);

    // Create a message
    var message = session.CreateTextMessage("Hello, ActiveMQ!");

    // Send the message
    producer.Send(message);
}

static void ReceiveMessage(ISession session, IQueue destination)
{
    var consumer = session.CreateConsumer(destination);

    var receivedMessage = consumer.Receive();

    if (receivedMessage is ITextMessage textMessage)
    {
        Console.WriteLine("Received message: " + textMessage.Text);
    }
}