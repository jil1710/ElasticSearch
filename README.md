
![image](https://github.com/jil1710/readmedemo/assets/125335932/26a866fd-9694-465e-a445-ff87052e235e)


# Elastic Search

- Elasticsearch is a free, open-source search and analytics engine based on the Apache Lucene library. It’s the most popular search engine and has been available since 2010.Elasticsearch is a highly scalable open-source full-text search and analytics engine. It allows you to store, search, and analyze big volumes of data quickly and in near real time. It is generally used as the underlying engine/technology that powers applications that have complex search features and requirements. Elasticsearch provides a distributed system on top of Lucene StandardAnalyzer for indexing and automatic type guessing and utilizes a JSON based REST API to refer to Lucene features.

- It is easy to set up out of the box since it ships with sensible defaults and hides complexity from beginners. It has a short learning curve to grasp the basics so anyone with a bit of efforts can become productive very quickly. It is schema-less, using some defaults to index the data.

- It is built in Java. Easy to use and highly scalable. Often used to provide search functionality to an application with features like auto complete, correcting typos, handling synonyms, logging etc...

## Key Features of ElasticSearch

 - **Distributed Architecture:** ElasticSearch is built to distribute data across multiple nodes, enabling horizontal scalability and high availability. It uses sharding and replication techniques to ensure data is distributed and replicated across the cluster.
   
 - **Full-Text Search:** ElasticSearch provides robust full-text search capabilities, allowing you to perform complex search queries across structured and unstructured data. It supports features like filtering, faceting, highlighting, and relevance scoring.

 - **Real-Time Data:** ElasticSearch is designed to handle real-time data ingestion and analytics. It allows you to index and search data in near real-time, making it suitable for applications that require up-to-date information and quick responses.

 - **Schema-less:** ElasticSearch is schema-less, meaning you can index and search documents without predefining a strict schema. It dynamically maps and indexes data based on its structure, which provides flexibility and simplifies the data indexing process.

 - **RESTful API:** ElasticSearch exposes a comprehensive RESTful API, allowing you to interact with the search engine using HTTP requests. This makes it easy to integrate ElasticSearch into various applications and programming languages.

 - **Aggregations and Analytics:** ElasticSearch offers powerful aggregation capabilities for performing data analytics and generating meaningful insights. Aggregations allow you to group, filter, and perform calculations on data sets, enabling you to extract valuable information from your indexed documents.
 
## Let's Understand Component and Terminology of Elastic search

- **Elasticsearch Components**

  - Cluster

    One or more servers collectively providing indexing and search capabilities form an Elasticsearch cluster. The cluster size can vary from a single node to thousands of nodes, depending on the use cases.

  - Node

    Node is a single physical or virtual machine that holds full or part of your data and provides computing power for indexing and searching your data. Every node is identified with a unique name. If the node identifier is not specified, a random UUID is assigned as a node identifier at the startup. Every node configuration has the property `cluster.name`. The cluster will be formed automatically with all the nodes having the same `cluster.name` at startup.

    - A node has to accomplish several duties like:

        - Storing the data.
        - Performing operations on data (indexing, searching, aggregation, etc.).
        - Maintaining the health of the cluster.
     
- Elasticsearch is standing as a NOSQL DB that store data as document type.

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/482f5abb-1d03-418c-a6f0-468734280553)

- Index

    Index is a container to store data similar to a database in the relational databases. An index contains a collection of documents that have similar characteristics or are logically related. If we take an example of an e-commerce website, there will be one index for products, one for customers, and so on. Indices are identified by the lowercase name. The index name is required to perform the add, update, or delete operations on the document.

- Type

  Type is a logical grouping of the documents within the index. In the previous example of product index, we can further group documents into types, like electronics, fashion, furniture, etc. Types are defined on the basis of documents having similar properties in it. It isn’t easy to decide when to use type over index. Indices have more overheads, so sometimes, it is better to use different types in the same index for better performance. There are a couple of restrictions to use types as well. Two fields having the same name in a different type of document should be of the same data type (string, date, etc).

- Document

    Document is the piece indexed by Elasticsearch. A document is represented in the JSON format. We can add as many documents as we want into an index. The following snippet shows how to create a document of type mobile in the index store.

## Data Type in Elastic Search

- Text

    This data type is used to store full text like product description. These fields participate in full-text search. These type of fields are analyzed while storing which enables to searching these fields by the individual word in it. These type of fields are not used in sorting and aggregation queries.

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/07249449-603f-481d-a521-67b8b2e33daf)


- Keywords

    This type is also used to store text data but unlike Text, it is not analyzed and stored as-is. This is suitable to store information like a user’s mobile number, city, age, etc. These fields are used in filter, aggregation and sorting queries. For e.g. list all users from a particular city, filter by their age.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/056fa496-1734-45e2-89eb-f9acc9df42c4)


- Numeric

  Elasticsearch supports a wide range of numeric type long, integer, short, byte, double, float.

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/6499525d-39ea-48d6-aa32-c52aa91f3745)


- Boolean & Data

  Elastic Search also support boolean and date type data to store boolean and date object.

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/8ebdd520-719b-40c7-b8cc-44529d67ff92)
  

- Object

  If you know JSON well, this is not a new concept. Elasticsearch also allows storing nested JSON object structure as a document.

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/db792faa-6e87-43e0-8714-fefdfe6b77a2)


- Nested

    The Object data type is not that useful due to its underlying data representation in the Lucene index. Lucene index does not support inner JSON object. ES flattens the original JSON to make it compatible to store in Lucene index. Due to this fields of the multiple inner objects get merged into one leading to wrong search results. Most of the time what you may want to use is Nested Datatype over Object.

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/7b072896-ef01-4d7a-9d4e-2c09cfe6fa6c)


- Geo Point

    This data type is used to store geographical location. It accepts latitude and longitude pair. To give an example, this data type can be used to arrange the user’s photo library by their geographical location or graphically display the locations which are trending on social media news.

- Geo Shape

    It allows storing arbitrary geometric shapes like rectangle, polygon.

- Below is the Scheme or Mapping of ablove data type

- **Example : Look below index :**

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/1df890d9-d4d3-4a36-a166-878c9bc91d90)

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/41ef854a-d683-4b67-a1d4-200300b2ed31)


## Let's implement Elastic Search using ASP.Net Core integration.

- First of all Download and Install Elasticsearch. You can download it from [here](https://www.elastic.co/downloads/elasticsearch). Once you downloaded Elasticsearch zip file, extract it and run `\bin\elasticsearch.bat`. After running this file, you should be able to browse https://localhost:9200. You can use this as your Elasticsearch server. You will also get your username, password, and other necessary information that you have to use in ASP.NET Core middleware.

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/5771f18f-9fe3-43e3-9380-9d5c643636ac)

- Now Install the below nuget package in order to cummunicate with elastic search server. Nest is a strongly typed interface to Elasticsearch. Fluent and classic object initializer mappings of requests and responses.

  ```csharp
     NEST
  ```

- Now Add Elastic Search Configuration or Add Elastic Search Services into dependency injection.

  ```json
   "ElasticSearchSettings": {
      "Uri": "https://localhost:9200/",
      "Username": "elastic",
      "Password": "j0Mx4ld2g+owizkbDxJo",
      "Thumbprint": "b2ae7dabf9881172d776d8e189ac67ef2a2021fe91df6634c99b6d60cc2d072e"
    }
  ```
  - Create one extention method that configure the elastic search setting and connection to create index and document.
 
    ![image](https://github.com/jil1710/readmedemo/assets/125335932/63fc3cdf-ac18-4d3f-bc5a-c0df3f5d148b)

  - Add this to Service collection to register the `IElasticClient` into DI container.
 
    ![image](https://github.com/jil1710/readmedemo/assets/125335932/a6b64282-3054-44bb-8f88-abfa691e0165)

 - We have Seed 300000 Customer data into Elastic Search to analysing and visulization of data we use kibana. It is a dashboard for practicing the elastic search such as create, delete index, mapping the index with type, insert, delete, update, read the document into particular index etc...

 - You can download kibana from [here](https://www.elastic.co/downloads/kibana). Once you download kibana zip file, extract it and run `\bin\kibana.bat`. After running this file it will give url to open dashboard once you click on this url it will ask for `enrollment token`. You get this token when you run `elasticsearch.bat` file below username nad password section. Just copy and paste into kibana dashboard after validation token it will ask for username and password. enter same below username and password. now you are ready to go. Go to `Dev Tool` to execute end points like create, delete, get etc..

   ![image](https://github.com/jil1710/readmedemo/assets/125335932/5771f18f-9fe3-43e3-9380-9d5c643636ac)

- **Search Customer by it's name into customer index**

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/03748038-a0fe-4cd8-865e-6bc0ff9cf7b2)

- **Search Customer by Account Type [ Saving, Fixed, Current ]**

  ![image](https://github.com/jil1710/readmedemo/assets/125335932/92ca6354-b205-4737-a9df-ead806aaedf9)

 - **Let's Perform CRUD operation on elastic search index**

   - Create model CRUD

     ![image](https://github.com/jil1710/readmedemo/assets/125335932/0607f2e9-69ce-4c27-bc99-be01ca682fe4)

   - Insert data document into elastic search index with name crud.

     ![image](https://github.com/jil1710/readmedemo/assets/125335932/98eeed94-e5a7-47b1-97f1-b527b580ca31)

   - Delete document from crud index
  
     ![image](https://github.com/jil1710/readmedemo/assets/125335932/b3227ac7-f0d9-4b78-84f8-46ce01865c18)

   - Update document of crud index
  
     ![image](https://github.com/jil1710/readmedemo/assets/125335932/a3b28d1f-6ec8-46c1-aaa2-90d35846174b)

   - Read document by id from crud index

     ![image](https://github.com/jil1710/readmedemo/assets/125335932/2079b872-4e6f-4677-9131-c86ade053745)



  
     












   